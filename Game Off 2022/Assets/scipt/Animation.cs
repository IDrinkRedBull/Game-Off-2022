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
    private int slashUp = Animator.StringToHash("Burger SlashUp");
    private int slashDown = Animator.StringToHash("Burger SlashDown");
    private int stab = Animator.StringToHash("Burger Stab");

    float cooldown = 0.3f;
    float resetTimer = 1;
    float secretTimer = 1;

    float numOfClick;
    float secretClick;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        cooldown -= Time.deltaTime;
        resetTimer -= Time.deltaTime;
        secretTimer -= Time.deltaTime;

        if (secretTimer < 0) numOfClick = 0;
        if (resetTimer < 0) secretClick = 0;

        if (Input.GetKeyDown(KeyCode.Mouse0) && cooldown < 0)
        {
            numOfClick++;
            if (numOfClick >= 4)
            {
                numOfClick = 1;
                secretClick = 1;
            }

            cooldown = 0.3f;
            resetTimer = 0.3f;
            secretTimer = 1f;
            secretClick = numOfClick;
        }
        
        var state = GetState();
        if (state == currentState) return;
        player.CrossFade(state, 0, 0);
        currentState = state;
    }

    private int currentState;
    private int GetState()
    {
        if (secretClick == 1) return slashUp;
        else if (secretClick == 2) return slashDown;
        else if (secretClick == 3) return stab;

        if (rb.velocity.y < -1 || rb.velocity.y > 1)
        {
            isJumping = true;
        }
        else isJumping = false;

        if (!isJumping) return rb.velocity.magnitude > 1 ? walk : idle;
        return 0;
    }
}
