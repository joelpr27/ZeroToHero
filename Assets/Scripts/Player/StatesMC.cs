using UnityEngine;


public class StatesMC : MC
{   public enum States { Idle, Run, Jump, Hit };

    [Header("Maquina de estados")]
    public States mcState = States.Idle;
    [HideInInspector] public bool canMove = true;
    public bool isHurt = false;
    public float stunLength;
    public float currentStunLength;
    
    public float movX;

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
                else if (movX != 0 && IsGrounded())
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
                else if (movX == 0 && IsGrounded())
                {
                    mcState = States.Idle;
                }
                if (isHurt)
                {
                    mcState = States.Hit;
                }
                break;

            case States.Jump:
                if (movX == 0 && IsGrounded())
                {
                    mcState = States.Idle;
                }
                else if (movX != 0  && IsGrounded())
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
            /* StartCoroutine(StunTime()); */
            isHurt = true;
        }
    }

    /* public IEnumerator StunTime()
    {
        yield return new WaitForSeconds(stunLength);
        isHurt = false;
        canMove = true;
    } */
}
