using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    private GameManager gm;
    private LevelInfo LI;

    public GameObject flyEnemy;

    [Header("Targget")]
    public GameObject targget;
    private Player player;
    [Space]

    [Header("Move")]
    public float speed;

    public Transform[] pointPatrol;
    private int targetPoint;

    public bool isPlayerDetected;

    public GameObject body;
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
        if(body.transform.position == pointPatrol[targetPoint].position)
        {
            NextTarget();
        }

        body.transform.position = Vector2.MoveTowards(body.transform.position, pointPatrol[targetPoint].position, speed * Time.deltaTime);
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

        body.transform.position = Vector2.MoveTowards(body.transform.position, targget.transform.position + new Vector3(0, 1.5f, 0), speed * Time.deltaTime);
    }
#endregion

void Start()
    {
        targget = GameObject.FindWithTag("Player");

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        LI = GameObject.Find("LevelInfo").GetComponent<LevelInfo>();

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
            Debug.Log("A");
            
            Instantiate(particle, transform.position, Quaternion.identity);
            Instantiate(particle, transform.position, Quaternion.identity);
            LI.Score();
            Destroy(flyEnemy);
        }

        if(other.tag == "Attack")
        {
            Debug.Log("A");
            
            Instantiate(particle, transform.position, Quaternion.identity);
            Instantiate(particle, transform.position, Quaternion.identity);
            LI.Score();
            Destroy(flyEnemy);
        }

        if(other.tag == "Ground")
        {
            Debug.Log("A");
            
            Instantiate(particle, transform.position, Quaternion.identity);
            Instantiate(particle, transform.position, Quaternion.identity);
            
            Destroy(flyEnemy);
        }
    }
}
