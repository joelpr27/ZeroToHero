using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [Header("Targget")]
    public GameObject player;
    public GameObject AttackPlayerDetect;
    public GameObject RangeNoDetect;
    public GameObject DetectPlayer;
    [Space]

    [Header("Move")]
    public bool staticEnemy;

    public float speed;

    public GameObject groundCheck;
    public bool facingRight;
    public bool isGrounded;
    public float circleRadious;

    public LayerMask grounLayer;

    public bool isPlayerDetected;
    [Space]

    [Header("Fight")]
    public GameObject enemyAttack;
    public int damage;
    public bool playerInSigth;
    [Space]

    [Header("Animaciones")]
    public Animator animator;
    public GameObject rueda;


    #region Combat
    public void ActiveStunPlayer()
    {
        enemyAttack.SetActive(true);
    }

    public void DesactiveStunPlayer()
    {
        enemyAttack.SetActive(false);
    }

    public void Attack()
    {
        if (playerInSigth == true)
        {
            animator.SetBool("Attack", true);
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }

    #endregion

    #region Move

    // TODO Revisar el cambio de dirección hacer uno que cambie bien porque direction = 1 no hace nada
    void FaceDirection(bool facingRight)
    {

        if (facingRight && transform.localScale.x < 0.0f)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = Mathf.Abs(localScale.x) * 1;
            transform.localScale = localScale;
        }
        
        if (!facingRight && transform.localScale.x > 0.0f)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = Mathf.Abs(localScale.x) * -1;
            transform.localScale = localScale;
        }
    }

    void Patrol()
    {
        if (!playerInSigth && facingRight)
        {
            transform.position = new Vector2(Mathf.MoveTowards(transform.position.x, transform.position.x + 1, speed * Time.deltaTime),
            transform.position.y);
        }

        if (!playerInSigth && !facingRight)
        {
            transform.position = new Vector2(Mathf.MoveTowards(transform.position.x, transform.position.x - 1, speed * Time.deltaTime),
            transform.position.y);
        }

        if (!isGrounded && transform.localScale.x < 0.0f)
        {
            facingRight = true;
        }

        if (!isGrounded && transform.localScale.x > 0.0f)
        {
            facingRight = false;
        }

        
        
        FaceDirection(facingRight);
        
    }

    void Pursue()
    {
        if (player.transform.position.x - transform.position.x == 0)
        {

        }
        else if (player.transform.position.x < transform.position.x)
        {
            facingRight = false;
        }
        else
        {
            facingRight = true;
        }


        FaceDirection(facingRight);

        if (!playerInSigth)
        {
            transform.position = new Vector2(Mathf.MoveTowards(transform.position.x, player.transform.position.x, (speed * 1.5f) * Time.deltaTime),
            transform.position.y);
        }
    }

    void Seguimiento()
    {
        AttackPlayerDetect.transform.position = gameObject.transform.position;
        RangeNoDetect.transform.position = gameObject.transform.position;
        DetectPlayer.transform.position = gameObject.transform.position;

        AttackPlayerDetect.transform.localScale = gameObject.transform.localScale;
        RangeNoDetect.transform.localScale = gameObject.transform.localScale;
        DetectPlayer.transform.localScale = gameObject.transform.localScale;
    }
    #endregion

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        LI = GameObject.Find("LevelInfo").GetComponent<LevelInfo>();

        #region Death
        currentEnemyHealth = enemyHealth;
        #endregion

        #region Patrol

        isPlayerDetected = false;
        facingRight = true;
        #endregion
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, circleRadious, grounLayer);

        Attack();

        if (!playerInSigth) rueda.transform.Rotate(0, 0, -25 * (5 * Time.deltaTime));


        Seguimiento();

        if (staticEnemy == false)
        {
            if (isGrounded == true)
            {
                if (isPlayerDetected == true)
                {
                    Pursue();
                }
                else
                {
                    Patrol();
                }
            }
            else
            {
                Patrol();
                isPlayerDetected = false;
            }
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        /* if (other.tag == "Attack")
        {
            if (currentEnemyHealth > 0)
            {
                Instantiate(particle, transform.position, Quaternion.identity);
                currentEnemyHealth--;
            }
            if (currentEnemyHealth <= 0)
            {
                Instantiate(particle, transform.position, Quaternion.identity);
                Instantiate(particle, transform.position, Quaternion.identity);
                LI.Score();
                Destroy(meleeEnemy);
            }
        } */
    }
}