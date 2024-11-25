using System.Collections;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    private GameManager gm;
    private LevelInfo LI;

    public GameObject meleeEnemy;

    [Header("Targget")]
    public GameObject player;
    public GameObject AttackPlayerDetect;
    public GameObject RangeNoDetect;
    public GameObject DetectPlayer;
    [Space]

    [Header("Move")]
    public bool staticEnemy;

    public float speed;

    public Transform[] pointPatrol;
    private int targetPoint;

    public bool isPlayerDetected;
    [Space]

    [Header("Fight")]
    public GameObject enemyAttack;
    public int damage;
    public bool playerInSigth;
    [Space]

    [Header("Helth")]
    public int enemyHealth = 1;
    public int currentEnemyHealth;

    public GameObject particle;

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
        if(playerInSigth == true)
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
    void FaceDirection(int direction)
    {
        Vector3 localScale = transform.localScale;
        localScale.x = Mathf.Abs(localScale.x) * direction;
        transform.localScale = localScale;
    }

    void Patrol()
    {
        if (transform.position.x == pointPatrol[targetPoint].position.x)
        {
            NextTarget();
        }

        if (pointPatrol[targetPoint].position.x < transform.position.x)
        {
            FaceDirection(-1);
        }
        else
        {
            FaceDirection(1);
        }

        transform.position = new Vector2(Mathf.MoveTowards(transform.position.x, pointPatrol[targetPoint].position.x, speed * Time.deltaTime),
        transform.position.y);
    }

    void NextTarget()
    {
        targetPoint++;
        if (targetPoint >= pointPatrol.Length)
        {
            targetPoint = 0;
        }
    }

    void Pursue()
    {
        if (player.transform.position.x < transform.position.x)
        {
            FaceDirection(-1);
        }
        else
        {
            FaceDirection(1);
        }

        transform.position = new Vector2(Mathf.MoveTowards(transform.position.x, player.transform.position.x, speed * Time.deltaTime),
        transform.position.y);
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

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        LI = GameObject.Find("LevelInfo").GetComponent<LevelInfo>();

        #region Death
        currentEnemyHealth = enemyHealth;
        #endregion

        #region Patrol
        targetPoint = 0;

        isPlayerDetected = false;
        #endregion
    }

    void Update()
    {
        Attack();

        rueda.transform.Rotate(0, 0, 5);

        Seguimiento();

        if (staticEnemy == false)
        {
            if (isPlayerDetected == false)
            {
                Patrol();
            }
            else
            {
                Pursue();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Attack")
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
        }
    }
}
