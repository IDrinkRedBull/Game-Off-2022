using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eating : MonoBehaviour
{
    public GameObject salad, tomato, meat, cheese;
    public GameObject point;
    public LayerMask food;
    public Slider bar;

    public float range;

    float eatAmount;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Charging bar
        bar.value = eatAmount;
        Collider2D[] hit = Physics2D.OverlapCircleAll(point.transform.position, range, food);

        foreach (Collider2D food in hit)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(food.gameObject);
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
}
