using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    private GameManager gm;

    [Header("Targget")]
    public Player player;
    [Space]

    [Header("Move")]
    public bool staticEnemy;

    public float speed;

    public Transform[] pointPatrol;
    private int targetPoint;

    public bool isPlayerDetected;
    public float playerDistance;
    [Space]

    [Header("Fight")]
    public float attackCooldown;
    private float cooldownTimer = Mathf.Infinity;
    public int damage;
    public bool playerInSigth;
    [Space]

    [Header("Helth")]
    public int enemyHealth = 1;
    public int currentEnemyHealth;

    public GameObject particle;

#region Combat
    public void StunPlayer()
    {
        if(playerInSigth == true)
        {
            player.playerIsStunning = true;
        }
    }

    public void Attack()
    {
        cooldownTimer += Time.deltaTime;
        if(playerInSigth == true)
        {
            if(cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;

                //Poner nombre del trigger de attack para la animacion
                //anim.SetTrigger("");
                Debug.Log("Attack");

                //quitar para que funcione con un trigger en la animacion
                StunPlayer();
            }
        }
    }
#endregion
    
#region Death
    //POR SI TENEMOS QUE AÑADIR COSAS DE LA VIDA

    //ESTA EN EL OnTrigger
#endregion

#region Patrol
    void Patrol()
    {
        if(transform.position == pointPatrol[targetPoint].position)
        {
            NextTarget();

            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }

        transform.position = Vector2.MoveTowards(transform.position, pointPatrol[targetPoint].position, speed * Time.deltaTime);
    }

    void NextTarget()
    {
        targetPoint++;
        if(targetPoint >= pointPatrol.Length)
        {
            targetPoint = 0;
        }
    }

    void Pursue()
    {
        //hecer el que te detecte como player para que gire a tu direccion

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
#endregion

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

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

        if(staticEnemy == false)
        {
            if(isPlayerDetected == false)
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
        if(other.tag == "Attack")
        {
            if(currentEnemyHealth > 0)
            {
                Instantiate(particle, transform.position, Quaternion.identity);
                currentEnemyHealth--;
            }
            if(currentEnemyHealth <= 0)
            {
                Instantiate(particle, transform.position, Quaternion.identity);
                Instantiate(particle, transform.position, Quaternion.identity);
                gm.Score();
                Destroy(gameObject);
            }
        }
    }
}
