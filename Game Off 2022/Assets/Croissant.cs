using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Croissant : MonoBehaviour
{
    public Transform rayPoint;
    public float range;
    Rigidbody2D rb;

    float direction = -1;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayPoint.position, Vector2.down, range);
        Debug.DrawRay(rayPoint.position, Vector2.down * range);

        if (hit.collider == null)
        {
            if (direction <= 0)
            {
                direction = 1;
                gameObject.transform.Rotate(0, 180, 0);
                Debug.Log("go left");
            }
            else
            {
                gameObject.transform.Rotate(0, -180, 0);
                direction = -1;
                Debug.Log("go right");
            }
        }

        rb.velocity = new Vector2(2 * direction, 0);
    }
}
