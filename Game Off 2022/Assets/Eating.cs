using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eating : MonoBehaviour
{
    public GameObject salad, tomato, meat, cheese;
    public GameObject point;
    public LayerMask food;
    public Sprite empty ,charge1, charge2, charge3, charge4;
    public Image image;

    public float range;

    float eatAmount;

    GameObject ob;

    public float eatDelay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        eatDelay -= Time.deltaTime;

        findEnemy();
        // Charging bar

        Collider2D[] hit = Physics2D.OverlapCircleAll(point.transform.position, range, food);

        foreach (Collider2D food in hit)
        {
            ob.GetComponent<EnemyScipt>().highlight = 0.02f;
            if (Input.GetKeyDown(KeyCode.E) && eatDelay <= 0)
            {
                eatDelay = 0.3f;
                Destroy(ob);
                eatAmount++;
            }

        }

        // Combating
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (eatAmount == 1) StartCoroutine(attack(salad, 0));
            else if (eatAmount == 2)
            {
                StartCoroutine(attack(tomato, 0));
                StartCoroutine(attack(tomato, 0.2f));
            }
            else if (eatAmount == 3) StartCoroutine(attack(meat, 0));
            else if (eatAmount == 4) StartCoroutine(attack(cheese, 0));
        }

        if (eatAmount == 0) image.sprite = empty;
        else if (eatAmount == 1) image.sprite = charge1;
        else if (eatAmount == 2) image.sprite = charge2;
        else if (eatAmount == 3) image.sprite = charge3;
        else if (eatAmount == 4) image.sprite = charge4;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(point.transform.position, range);
    }

    IEnumerator attack(GameObject prefab, float s)
    {
        yield return new WaitForSeconds(s);
        Instantiate(prefab, transform.position, Quaternion.identity);
        eatAmount = 0;
    }

    void findEnemy()
    {
        float disToClosestEnemy = Mathf.Infinity;
        EnemyScipt closestEnemy = null;

        // Find all enemy and put them in a array
        EnemyScipt[] allEnemies = GameObject.FindObjectsOfType<EnemyScipt>();

        // check all enemy and see which one is closer
        foreach (EnemyScipt currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - transform.position).sqrMagnitude;
            if (distanceToEnemy <= disToClosestEnemy)
            {
                // Set the distance to the cloest enemy
                disToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
                ob = closestEnemy.gameObject;
            }
        }
    }
}
