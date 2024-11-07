using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    private GameManager gm;

    [Header("Targget")]
    public Player player;
    [Space]

    [Header("Move")]
    public float speed;

    public Transform[] pointPatrol;
    private int targetPoint;

    public bool isPlayerDetected;
    [Space]

    [Header("Fight")]
    public int damage;
    [Space]

    [Header("Helth")]
    public GameObject particle;
    
#region Combat
    public void StunPlayer()
    {
        player.playerIsStunning = true;
    }
#endregion

#region Patrol
    void Patrol()
    {
        if(transform.position == pointPatrol[targetPoint].position)
        {
            NextTarget();
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

        #region Patrol
            targetPoint = 0;

            isPlayerDetected = false;
        #endregion
    }

void Update()
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

public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StunPlayer();
            Debug.Log("A");
            
            Instantiate(particle, transform.position, Quaternion.identity);
            Instantiate(particle, transform.position, Quaternion.identity);
            gm.Score();
            Destroy(gameObject);
        }

        if(other.tag == "Attack")
        {
            Debug.Log("A");
            
            Instantiate(particle, transform.position, Quaternion.identity);
            Instantiate(particle, transform.position, Quaternion.identity);
            gm.Score();
            Destroy(gameObject);
        }
    }
}
