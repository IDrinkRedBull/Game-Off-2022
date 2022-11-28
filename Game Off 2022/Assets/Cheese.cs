using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    Vector2 pos;
    Transform player;
    Movement movement;

    bool flyBack;
    float direction;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();

        if (movement.isFacingRight) direction = 1;
        else if (!movement.isFacingRight) direction = -1;

        pos = new Vector2(transform.position.x + 15 * direction, transform.position.y);
        flyBack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!flyBack) transform.position = Vector2.Lerp(transform.position, pos, 4.8f * Time.deltaTime);

        Invoke("boomerang", 0.8f);

        if ((transform.position - player.position).magnitude <= 5 && flyBack)
        {
            Destroy(gameObject);
        }
        Debug.Log((transform.position - player.position).magnitude);
    }

    void boomerang()
    {
        transform.position = Vector2.Lerp(transform.position, player.position, 2 * Time.deltaTime);
        flyBack = true;
    }
}
