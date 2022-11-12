using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Animator player;
    Rigidbody2D rb;

    bool isJumping;
    // Animator.StringToHash convert the animation string to int
    private int idle = Animator.StringToHash("Burger Idle");
    private int walk = Animator.StringToHash("Burger Walk");
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var state = GetState();

        player.CrossFade(state, 0, 0);
    }

    private int currentState;
    private int GetState()
    {
        if (rb.velocity.y < -1 || rb.velocity.y > 1)
        {
            isJumping = true;
        }
        else isJumping = false;

        if (!isJumping) return rb.velocity.magnitude > 1 ? walk : idle;
        return 0;
    }
}
