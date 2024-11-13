using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ArcherEnemy : MonoBehaviour
{
    private GameManager gm;

    public GameObject archerEnemy;

    [Header("Targget")]
    public GameObject player;
    [Space]

    [Header("Move")]
    public bool isPlayerDetected;
    [Space]

    [Header("Fight")]
    public float attackCooldown;
    private float cooldownTimer = Mathf.Infinity;
    public int damage;
    [Space]

    public Transform bow;
    public GameObject arrow;
    [Space]

    [Header("Helth")]
    public GameObject particle;

#region Move
    void FaceDirection(int direction)
    {
        Vector3 localScale = transform.localScale;
        localScale.x = direction;
        transform.localScale = localScale;
    }
    void PlayerDirection()
    {
        if (player.transform.position.x < transform.position.x)
        {
            FaceDirection(1);
        }
        else
        {
            FaceDirection(-1);
        }

    }

    void TrakingPlayer()
    {
        Vector3 direction = player.transform.position - bow.position;
        //calcula la tangente
        float angle = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        //
        bow.rotation = Quaternion.Euler(0, 0, angle);
    }
#endregion
    
#region Combat

    void SpawnArriw()
    {
        Debug.Log("Attack");

        Instantiate(arrow, bow.position, bow.rotation);
    }

    void Attack()
    {
        cooldownTimer += Time.deltaTime;

        if(cooldownTimer >= attackCooldown)
        {
            cooldownTimer = 0;

            SpawnArriw();
        }
    }
#endregion

    void Start()
    {
        player = GameObject.Find("Player");
        
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        #region Patrol
            isPlayerDetected = false;
        #endregion
    }

    void Update()
    {
        if(isPlayerDetected == true)
        {
            PlayerDirection();
            TrakingPlayer();

            Attack();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Attack")
        {
            Debug.Log("A");
            
            Instantiate(particle, transform.position, Quaternion.identity);
            Instantiate(particle, transform.position, Quaternion.identity);
            gm.Score();
            Destroy(archerEnemy);
        }
    }
}
