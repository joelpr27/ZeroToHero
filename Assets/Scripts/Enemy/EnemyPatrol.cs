using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject player;

    public Transform[] pointPatrol;
    private int targetPoint;
    public float speed;

    public bool isPlayerDetected;

    void Patrol()
    {
        if(transform.position == pointPatrol[targetPoint].position)
        {
            NextTarget();

            Flip();
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

    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void Pursue()
    {
        //hecer el que te detecte como player para que gire a tu direccion
        // if()
        // {

        // }

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void Start()
    {
        targetPoint = 0;

        isPlayerDetected = false;
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
}
