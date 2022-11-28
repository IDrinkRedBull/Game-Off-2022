using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineapleFly : MonoBehaviour
{
    float bozz = 10;
    public Rigidbody2D rb;
    public LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-8, -10);
        float y = Random.Range(-1, 5);
        rb.velocity = new Vector2(x, y);

    }



    /*
    void OnTriggerEnter2D(Collider2D Hit)
    {
        
        Debug.Log(taged);
        if(Hit.tag == "Player")
        {
            
            
            Debug.Log("hit a player");
        }
        if (Hit.tag != "Pizza")
        {
            //Destroy(gameObject);
        }
    }
    */

    /*
    void OnCollisionEnter2D(Collision2D Hit)
    {
        /*
        Debug.Log(taged);
        if (taged.Equals("Player"))
        {
            

            Debug.Log("hit a player");
        }
        if (taged.Equals("Pizza"))
        {
            //Destroy(gameObject);
        }
        
        if (Hit.gameObject.tag == "TongTong")
        {
            rb.velocity = new Vector2(rb.velocity.x, y);
            Debug.Log("work");
        }

        Destroy(gameObject, 2f);


    }
    */


    private void OnTriggerEnter2D(Collider2D Hit)
    {
        if (Hit.gameObject.tag == "TongTong")
        {
            rb.velocity = new Vector2(rb.velocity.x, bozz);
            Debug.Log("work");
        }
        if (Hit.gameObject.tag == "WallPizza")
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }


        Destroy(gameObject, 5f);

    }









}
