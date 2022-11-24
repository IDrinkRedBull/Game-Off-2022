using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Animator player;
    Rigidbody2D rb;
    Eating eating;

    bool isJumping;
    public float eatDelay;
    float lockedTill;

    // Animator.StringToHash convert the animation string to int
    private int idle = Animator.StringToHash("Burger Idle");
    private int walk = Animator.StringToHash("Burger Walk");
    private int jump = Animator.StringToHash("Burger Jump");
    private int fall = Animator.StringToHash("Burger Fall");
    private int eat = Animator.StringToHash("Burger Eat");

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        eating = gameObject.GetComponent<Eating>();
    }

    // Update is called once per frame
    void Update()
    {      
        eatDelay -= Time.deltaTime;
        var state = GetState();

        if (state == currentState) return;
        player.CrossFade(state, 0, 0);
        currentState = state;
    }

    private int currentState;
    private int GetState()
    {
        if (Time.time < lockedTill) return currentState;

        if (eating.eatDelay > 0) return LockState(eat, 0);

        if (rb.velocity.y < -1 || rb.velocity.y > 1)
        {
            isJumping = true;
        }
        else isJumping = false;

        if (!isJumping) return rb.velocity.magnitude > 1 ? walk : idle;
        return rb.velocity.y > 1 ? jump : fall;

        int LockState(int animation, int time)
        {
            lockedTill = Time.time + time;
            return animation;
        }
    }
}
