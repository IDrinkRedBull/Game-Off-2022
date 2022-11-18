using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float horizonetal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 12f;
    public bool isFacingRight = true;
    bool DoubleJump = true;
    [SerializeField] private Rigidbody2D apple;
    [SerializeField] private Transform groundX;
    [SerializeField] private LayerMask groundZ;


    // Update is called once per frame
    void Update()
    {
        horizonetal = Input.GetAxisRaw("Horizontal");
        flip();

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            apple.velocity = new Vector2(apple.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && apple.velocity.y > 0f)
        {
            apple.velocity = new Vector2(apple.velocity.x, apple.velocity.y * 0.5f);
        }
        //Debug.Log(apple.velocity);
        if (Input.GetButtonDown("Jump") && DoubleJump)
        {
            apple.velocity = new Vector2(apple.velocity.x, jumpingPower);
            DoubleJump =!DoubleJump;
        }
        if (IsGrounded())
        {
            DoubleJump = true;
        }
    }

    private bool IsGrounded()// ground check
    {
        return Physics2D.OverlapCircle(groundX.position, 0.2f, groundZ);
    }

    private void FixedUpdate()
    {
        apple.velocity = new Vector2(horizonetal * speed, apple.velocity.y);
    }

    private void flip()
    {
        if (isFacingRight && horizonetal < 0f || !isFacingRight && horizonetal > 0f)
        {


            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
            /*
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            */
        }
    }

    public void Dasforward()
    {
        apple.velocity = new Vector2(3, 0);
    }

}
