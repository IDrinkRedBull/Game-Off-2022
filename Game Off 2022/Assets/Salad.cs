using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salad : MonoBehaviour
{
    Rigidbody2D rb;
    Movement movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        if (movement.isFacingRight) rb.velocity = Vector3.right * 15;
        else rb.velocity = Vector3.left * 15;

        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
