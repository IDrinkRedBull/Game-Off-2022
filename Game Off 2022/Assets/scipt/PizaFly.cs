using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizaFly : MonoBehaviour
{
    float y;
    public Rigidbody2D rb;
    public LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        
        y = Random.Range(-5f, -10f);
        rb.velocity = new Vector2(0,y);
        
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
        */
        

        Destroy(gameObject);
        

    }




}
