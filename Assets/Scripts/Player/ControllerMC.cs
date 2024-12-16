using System.Collections;
using UnityEngine;
using Mirror;

public class ControllerMC : StatesMC
{
    private LevelInfo levelInfo;
    private GameManager GM;
    public GameObject guardado;

    [Header("Controller")]

    public Vector2 speed;
    public float maxSpeedX;
    public float loadedSpeed;
    public float dashSpeed;
    public float maxDashSpeed;
    public float dashLength;
    public GameObject dashTrail;
    public GameObject rockPrefab;
    public GameObject rockPLaceholder;
    [Space]
    GameObject spawnPoint;
    float punchAnimLength = 0.5f;
    bool loaded = false;
    bool dash = false;
    bool dashReady = true;
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


        if (Input.GetButton(punch) && !anim.GetBool("AttackAtlas") && !anim.GetBool("AttackZeus") && isLocalPlayer)
        {
            anim.SetBool("Attack", true);
            anim.SetLayerWeight(1, 1);
        }

        if (punchAnimLength <= 0.0f && !Input.GetButton(punch))
        {
            punchAnimLength = 0.5f;
             anim.SetBool("Attack", false);
            anim.SetLayerWeight(1, 0);
        }

    }

    void SpecialAttack()
    {

        if (AtlasPowerUpOn)
        {

            if (Input.GetButton(powerUpAttack) && !loaded && IsGrounded() && !anim.GetBool("AttackAtlas"))
            {
                StartCoroutine(AtlasPullAnimTime());
            }

            if (Input.GetButton(powerUpAttack) && loaded && anim.GetBool("AttackAtlas"))
            {
                StartCoroutine(AtlasThrowAnimTime());
            }


            IEnumerator AtlasPullAnimTime()
            {
                canMove = false;
                anim.SetLayerWeight(1, 1);
                anim.SetBool("AttackAtlas", true);

                yield return new WaitForSeconds(1.5f);

                canMove = true;
                loaded = true;
            }

            IEnumerator AtlasThrowAnimTime()
            {
                canMove = false;
                anim.SetBool("AttackAtlas", false);
                yield return new WaitForSeconds(1.0f);
                anim.SetLayerWeight(1, 0);
                
                loaded = false;
                canMove = true;
            }

        }

        if (ZeusPowerUpOn)
        {
            if (Input.GetButton(powerUpAttack) && !anim.GetBool("AttackZeus"))
            {
                StartCoroutine(ZeusAnimTime());
            }

            IEnumerator ZeusAnimTime()
            {
                anim.SetBool("AttackZeus", true);
                anim.SetLayerWeight(1, 1);
                canMove = false;
                movX=0;

                yield return new WaitForSeconds(1.0f);

                anim.SetBool("AttackZeus", false);
                anim.SetLayerWeight(1, 0);
                canMove = true;
            }

        }
    }
    public void SpawnRock(){
        GameObject newRock = Instantiate(rockPrefab, rockPLaceholder.transform.position, Quaternion.identity);
        newRock.transform.localScale = transform.localScale;
        newRock.GetComponent<Rock>().LaunchRock(transform.localScale);
    }
    void Dash()
    {
        if (IrisPowerUpOn && Input.GetButtonDown(powerUpMovement) && !dash && dashReady)
        {
            StartCoroutine(DashTime());
        }
    }
    IEnumerator DashTime()
    {
        dash = true;
        dashTrail.SetActive(true);
        yield return new WaitForSeconds(dashLength);
        dash = false;
        dashTrail.SetActive(false);
        StartCoroutine(DashCd());
    }
    IEnumerator DashCd()
    {
        dashReady = false;
        yield return new WaitForSeconds(dashLength * 2);
        dashReady = true;
    }

    //Suplementary Functions
    
    private void TurnCharacter()
    {
        if (!dash)
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
    }

    public void Start()
    {
        spawnPoint = GameObject.FindWithTag("Respawn");
        transform.position = spawnPoint.transform.position;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    void Update()
    {
        TurnCharacter();

        if(!isLocalPlayer)
        {
            return;
        }

        if(isServer)
        {
            HermesPowerUpOn = false;

            ZeusPowerUpOn = false;

            IrisPowerUpOn = true;

            AtlasPowerUpOn = false;
        }
        else
        {
            HermesPowerUpOn = true;

            ZeusPowerUpOn = false;

            IrisPowerUpOn = false;

            AtlasPowerUpOn = false;
        }

        if(true)
        {
            UpdateState();
        }

        /* if(HermesPowerUpOn != GM.IsDobleJump) HermesPowerUpOn = GM.IsDobleJump;
        if(IrisPowerUpOn != GM.IsDash) IrisPowerUpOn = GM.IsDash;
        if(AtlasPowerUpOn != GM.IsRock) AtlasPowerUpOn = GM.IsRock;
        if(ZeusPowerUpOn != GM.IsLightPU) ZeusPowerUpOn = GM.IsLightPU; */

        //Debug.Log(IsGrounded());
        

        switch (mcState)
        {
            case States.Idle:
                
                anim.SetInteger("State", 0);
                //posibles Mecanicas en el estado Idle
                    Jump();
                    Attack();
                    SpecialAttack();
                    Dash();
                
                break;

            case States.Run:
                anim.SetInteger("State", 1);
                //posibles Mecanicas en el estado Run
                    Jump();
                    Attack();
                    SpecialAttack();
                    Dash();
                    TurnCharacter();
                
                break;

            case States.Jump:
                anim.SetInteger("State", 2);
                //posibles Mecanicas en el estado Jump
                    Jump();
                    Attack();
                    SpecialAttack();
                    Dash();
                    TurnCharacter();
                
                break;

            case States.Hit:
            
                canMove = false;
                anim.SetInteger("State", 3);
                anim.SetLayerWeight(1, 0);
                anim.SetBool("AttackAtlas", false);
                anim.SetBool("AttackZeus", false);
                dash = false;
                loaded = false;
                break;

        }

        if(isHurt)
        {
            currentStunLength += Time.deltaTime;

            /* isHurt = true; */

            if(currentStunLength >= stunLength)
            {
                currentStunLength = 0;

                isHurt = false;
                canMove = true;
            }
            Debug.Log("Stun");
        }
    }

    void FixedUpdate()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        if (canMove || !IsGrounded())
        {
            if (!dash) movX = Input.GetAxis("Horizontal");


            float tgtVelocityX;

            if (loaded == true)
            {
                tgtVelocityX = speed.x * (movX / loadedSpeed);
            }
            else
            {
                tgtVelocityX = speed.x * movX;
            }

            if (Mathf.Abs(tgtVelocityX) > maxSpeedX)
            {
                tgtVelocityX = Mathf.Sign(tgtVelocityX) * maxSpeedX;
            }

            if (Mathf.Abs(dashSpeed) > maxDashSpeed)
            {
                dashSpeed = Mathf.Sign(dashSpeed) * maxDashSpeed;
            }

            if (dash)
            {
                rb.velocity = new Vector2(dashSpeed * movX, 0);
            }
            else
            {
                rb.velocity = new Vector2(tgtVelocityX, rb.velocity.y);
            }

        }
        else
        {
            rb.velocity = Vector2.zero;
        }


    }
}