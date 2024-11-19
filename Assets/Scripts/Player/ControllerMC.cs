using Unity.VisualScripting;
using UnityEngine;

public class ControllerMC : StatesMC
{
    [Header("Movimiento")]

    public Vector2 speed;
    public float maxSpeedX;
    float movX;

    [Header("PowerUps's")]
    public bool HermesPowerUpOn;
    private bool doubleJump;




//Main Actions of the character
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
                
                if (HermesPowerUpOn)
                {
                    doubleJump = !doubleJump;
                }
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    void Attack() {
        if(Input.GetButtonDown(punch))
        {
            anim.SetBool("Attack", true);
            anim.SetLayerWeight(1,1);
        }

        if(Input.GetButtonUp(punch))
        {
            anim.SetBool("Attack", false);
            anim.SetLayerWeight(1,0);
        }
    }


//Suplementary Functions
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void TurnCharacter(){
        if (movX < 0.0f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        if (movX > 0.0f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    void Update()
    {
        UpdateState();


        switch(mcState)
        {
            case States.Idle:
                
                anim.SetInteger("State", 0);
                //posibles Mecanicas en el estado Idle
                Jump();
                Attack();
                
            break;

            case States.Run:
                anim.SetInteger("State", 1);
                //posibles Mecanicas en el estado Run
                Jump();
                Attack();
                TurnCharacter();
            break;

            case States.Jump:
                anim.SetInteger("State", 2);
                //posibles Mecanicas en el estado Jump
                Jump();
                Attack();
                TurnCharacter();
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