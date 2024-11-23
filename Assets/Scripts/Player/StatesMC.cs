
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class StatesMC : MC
{
    [Header("Maquina de estados")]
    public States mcState;
    public enum States { Idle, Run, Jump, Hit };
    [HideInInspector] public bool canMove = true;
    bool isHurt = false;
    public float stunLength;

    // Start is called before the first frame update
    void Start()
    {
        mcState = States.Idle;
    }

    /// <summary>
    /// Checks The state the Character is And changes it if nescesary.
    /// </summary>
    public void UpdateState()
    {
        switch (mcState)
        {
            case States.Idle:
                if (!IsGrounded())
                {
                    mcState = States.Jump;
                }
                else if (rb.velocity.x != 0.0f && IsGrounded())
                {
                    mcState = States.Run;
                }
                if (isHurt)
                {
                    mcState = States.Hit;
                }
                break;

            case States.Run:
                if (!IsGrounded())
                {
                    mcState = States.Jump;
                }
                else if (rb.velocity.x == 0.0f && IsGrounded())
                {
                    mcState = States.Idle;
                }
                if (isHurt)
                {
                    mcState = States.Hit;
                }
                break;

            case States.Jump:
                if (rb.velocity.x == 0.0f && IsGrounded())
                {
                    mcState = States.Idle;
                }
                else if (rb.velocity.x != 0.0f && IsGrounded())
                {
                    mcState = States.Run;
                }
                if (isHurt)
                {
                    mcState = States.Hit;
                }
                break;

            case States.Hit:
                if (!isHurt)
                {
                    mcState = States.Idle;
                }
                break;
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyAttack")
        {
            isHurt = true;
            canMove = false;
            StartCoroutine(StunTime());
        }
    }

    IEnumerator StunTime()
    {
        yield return new WaitForSeconds(stunLength);
        isHurt = false;
        canMove = true;
    }
}
