using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eating : MonoBehaviour
{
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
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(point.transform.position, range);
    }
}
