using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizaFly : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-4, -10);
        float y = Random.Range(5, 10);
        rb.velocity = new Vector2(x,y);
    }

    void OnTriggerEnter2D(Collider2D Hit)
    {
        if(Hit.tag == "Player")
        {
            
            Debug.Log("hit a player");
        }
        if (Hit.tag != "Pizza")
        {
            Destroy(gameObject);
        }
    }





}
