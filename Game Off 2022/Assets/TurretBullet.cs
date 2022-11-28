using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-6, 6), 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < -10) rb.drag = 5;
        else rb.drag = 0;
    }
}
