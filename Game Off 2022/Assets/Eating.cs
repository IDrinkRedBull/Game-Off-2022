using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Eating : MonoBehaviour
{
    public GameObject door;
    public GameObject effectPrefab, effectPos;
    public GameObject cutscene;
    Rigidbody2D rb;
    public GameObject salad, tomato, meat, cheese;
    public GameObject point;
    public LayerMask food;
    public Sprite empty, empty2 ,charge1, charge2, charge3, charge4, hp1, hp2;
    public Image charges, health;
    GameObject ob;
    public GameObject forks;

    float hp;
    public float range;
    public float eatAmount;
    public float eatDelay;
    float invincibility;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = 2;
    }

    // Update is called once per frame
    void Update()
    {
        eatDelay -= Time.deltaTime;
        invincibility -= Time.deltaTime;

        if (invincibility >= 1.8) rb.gameObject.GetComponent<Movement>().enabled = false;
        else rb.gameObject.GetComponent<Movement>().enabled = true;

        if (invincibility >= 0)
        {
            Physics2D.IgnoreLayerCollision(8, 10);
            Physics2D.IgnoreLayerCollision(8, 7);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(8, 10, false);
            Physics2D.IgnoreLayerCollision(8, 7, false);
        }

        Collider2D[] hit = Physics2D.OverlapCircleAll(point.transform.position, range, food);

        foreach (Collider2D food in hit)
        {
            // Find all enemy and put them in a array
            float disToClosestEnemy = Mathf.Infinity;
            CanEat closestEnemy = null;

            // check all enemy and see which one is closer
            foreach (Collider2D currentEnemy in hit)
            {
                float distanceToEnemy = (currentEnemy.gameObject.transform.position - transform.position).sqrMagnitude;
                if (distanceToEnemy <= disToClosestEnemy)
                {
                    // Set the distance to the cloest enemy
                    disToClosestEnemy = distanceToEnemy;
                    closestEnemy = currentEnemy.GetComponent<CanEat>();
                    ob = currentEnemy.gameObject;
                }
            }

            forks.transform.position = new Vector2(ob.transform.position.x, ob.transform.position.y + 1);
            //ob.GetComponent<CanEat>().highlight = 0.02f;
            if (Input.GetKeyDown(KeyCode.Mouse1) && eatDelay <= 0)
            {
                if (!ob.gameObject.GetComponent<CanEat>().isBoss)
                {
                    eatDelay = 0.3f;
                    Destroy(ob);
                    eatAmount++;
                    Invoke("effect", 0.2f);
                }
                else if (ob.gameObject.GetComponent<CanEat>().isBoss)
                {
                    door.SetActive(true);
                    cutscene.SetActive(true);
                    gameObject.GetComponent<Movement>().enabled = false;
                    Destroy(ob);
                    Invoke("effect", 0.2f);
                }
            }


        }
        if (hit.Length > 0) forks.SetActive(true);
        else forks.SetActive(false);


        // Combating
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (eatAmount >= 5) eatAmount = 4;
            if (eatAmount == 1) StartCoroutine(attack(salad, 0));
            else if (eatAmount == 2)
            {
                StartCoroutine(attack(tomato, 0));
                StartCoroutine(attack(tomato, 0.3f));
            }
            else if (eatAmount == 3) hp++;
            else if (eatAmount == 4) StartCoroutine(attack(cheese, 0));


            eatAmount = 0;
        }

        if (eatAmount == 0) charges.sprite = empty;
        else if (eatAmount == 1) charges.sprite = charge1;
        else if (eatAmount == 2) charges.sprite = charge2;
        else if (eatAmount == 3) charges.sprite = charge3;
        else if (eatAmount == 4) charges.sprite = charge4;

        if (hp == 0) health.sprite = empty2;
        else if (hp == 1) health.sprite = hp1;
        else if (hp == 2) health.sprite = hp2;
        if (hp < 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        else if (hp > 2) hp = 2;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(point.transform.position, range);
    }

    IEnumerator attack(GameObject prefab, float s)
    {
        yield return new WaitForSeconds(s);
        Instantiate(prefab, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy Bullet" && invincibility <= 0)
        {
            hp--;
            invincibility = 2f;
            if (transform.position.x <= collision.transform.position.x) rb.velocity = new Vector2(-3, 5);
            else rb.velocity = new Vector2(3, 5);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy Bullet" && invincibility <= 0)
        {
            hp--;
            invincibility = 2f;
            if (transform.position.x <= collision.transform.position.x) rb.velocity = new Vector2(-3, 5);
            else rb.velocity = new Vector2(3, 5);
        }
    }

    void effect()
    {  
        Instantiate(effectPrefab, effectPos.transform.position, Quaternion.identity);
    }
}
