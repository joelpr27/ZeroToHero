using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class MovementMC : StatesMC
{
    [Header("Movimiento")]
/// <summary>
/// .x Horizontal / .y Vertical
/// </summary>
    public Vector2 speed;
    public float maxSpeedX;
    private bool doubleJump;

    public Transform groundCheck;
    public LayerMask groundLayer;

    float movX;
    float movY;
    
    void Jump()
    {
         if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, speed.y);

                doubleJump = !doubleJump;
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

 /// <summary>
 /// Checks if the player is grounded
 /// </summary>
 /// <returns>true if the ground check object is overlaping with an pobject in the ground later / false if not overlapping </returns>
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


    void Update()
    {
        switch(mcState)
        {
            case States.Idle:
                anim.SetInteger("States", 0);
                //posibles Mecanicas
                Jump();
            break;

            case States.Run:
                anim.SetInteger("States", 1);

                if (movX < 0.0f)
                {
                    transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
                else
                {
                    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }

                movY = 0;
                //posibles mecanicas
                if(Input.GetKeyDown("space"))
                {
                    rb.velocity = new Vector2(rb.velocity.x, speed.y); //Saltar
                }
            break;

            case States.Jump:
                anim.SetInteger("States", 2);
            break;

        }
        
    }
    
    void FixedUpdate()
    {
        movX = Input.GetAxis("Horizontal");

        float tgtVelocityX = speed.x * movX ;

        if (Mathf.Abs(tgtVelocityX) > maxSpeedX)
        {
            tgtVelocityX = Mathf.Sign(tgtVelocityX) * maxSpeedX;
        }

        rb.velocity = new Vector2(tgtVelocityX, rb.velocity.y);
    }
}