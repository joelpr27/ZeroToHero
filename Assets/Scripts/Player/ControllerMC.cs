using Unity.VisualScripting;
using UnityEngine;

public class ControllerMC : StatesMC
{
    [Header("Controller")]

    public Vector2 speed;
    public float loadedSpeed;
    public float maxSpeedX;
    float movX;
    float punchAnimLength = 0.64f;
    float zeusAnimLength = 2.0f;
    float rockPullAnimLength = 1.5f;
    float rockThrowAnimLength = 1.0f;
    bool canMove = true;
    bool loaded = false;
    bool doubleJump;




    //Main Actions of the character
    void Jump()
    {
        if (IsGrounded() && !Input.GetButton("Jump") && canMove)
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

    void Attack()
    {
        if (anim.GetBool("Attack"))
        {
            punchAnimLength -= Time.deltaTime;
        }


        if (Input.GetButton(punch))
        {
            anim.SetBool("Attack", true);
            anim.SetLayerWeight(1, 1);
        }

        if (punchAnimLength <= 0.0f && !Input.GetButton(punch))
        {
            punchAnimLength = 0.64f;
            anim.SetBool("Attack", false);
            anim.SetLayerWeight(1, 0);
        }
    }

    void SpecialAttack()
    {


        if (AtlasPowerUpOn)
        {
            //recoger roca
            if (anim.GetBool("AttackAtlas") && loaded == false)
            {
                rockPullAnimLength -= Time.deltaTime;
                movX = 0;
                canMove = false;
            }


            if (Input.GetButton(powerUpAttack) && loaded == false)
            {

                rockThrowAnimLength = 0.0f;
                anim.SetLayerWeight(1, 1);
                anim.SetBool("AttackAtlas", true);
            }

            
            if (rockPullAnimLength <= 0.0f && !Input.GetButton(powerUpAttack) && loaded == false)
            {
                rockPullAnimLength = 1.5f;
                canMove = true;
                loaded = true;
            }

            //Lanzar roca
            if (rockThrowAnimLength > 0.0f && loaded == true)
            {
                rockThrowAnimLength -= Time.deltaTime;
                movX = 0;
                canMove = false;
            }


            if (Input.GetButton(powerUpAttack) && loaded == true)
            {
                rockThrowAnimLength = 1.0f;
                anim.SetBool("AttackAtlas", false);
            }
            
            if (rockThrowAnimLength <= 0.0f && !Input.GetButton(powerUpAttack) && !anim.GetBool("AttackAtlas"))
            {
                rockThrowAnimLength = 1.0f;
                anim.SetLayerWeight(1, 0);
                canMove = true;
                loaded = false;
            }

        }

        if (ZeusPowerUpOn)
        {
            if (anim.GetBool("AttackZeus"))
            {
                zeusAnimLength -= Time.deltaTime;
                movX = 0;
                canMove = false;
            }


            if (Input.GetButton(powerUpAttack))
            {
                anim.SetBool("AttackZeus", true);
                anim.SetLayerWeight(1, 1);
            }

            if (zeusAnimLength <= 0.0f && !Input.GetButton(powerUpAttack))
            {
                zeusAnimLength = 2.0f;
                anim.SetBool("AttackZeus", false);
                anim.SetLayerWeight(1, 0);
                canMove = true;
            }

        }
    }


    //Suplementary Functions
    private void TurnCharacter()
    {

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

        switch (mcState)
        {
            case States.Idle:

                anim.SetInteger("State", 0);
                //posibles Mecanicas en el estado Idle
                Jump();
                Attack();
                SpecialAttack();

                break;

            case States.Run:
                anim.SetInteger("State", 1);
                //posibles Mecanicas en el estado Run
                Jump();
                Attack();
                SpecialAttack();
                TurnCharacter();
                break;

            case States.Jump:
                anim.SetInteger("State", 2);
                //posibles Mecanicas en el estado Jump
                Jump();
                Attack();
                SpecialAttack();
                TurnCharacter();
                break;

        }

    }

    void FixedUpdate()
    {
        if (canMove || !IsGrounded())
        {
            movX = Input.GetAxis("Horizontal");
        }

        float tgtVelocityX;

        if (loaded == true)
        {
            tgtVelocityX = speed.x * (movX/loadedSpeed);
        }
        else
        {
            tgtVelocityX = speed.x * movX;
        }

        if (Mathf.Abs(tgtVelocityX) > maxSpeedX)
        {
            tgtVelocityX = Mathf.Sign(tgtVelocityX) * maxSpeedX;
        }

        rb.velocity = new Vector2(tgtVelocityX, rb.velocity.y);
    }
}