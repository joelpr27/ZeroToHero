using Unity.Properties;
using UnityEngine;
using UnityEngine.Animations;

public class StatesMC : MC
{
    [Header("Maquina de estados")]
    public States mcState;
    public enum States{Idle, Run, Jump, Hit};  
    [HideInInspector]public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        mcState = States.Idle;
    }

/// <summary>
/// Checks The state the Character is And changes it if nescesary.
/// </summary>
    public void UpdateState(){
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
                break;

            case States.Hit:
                

                break;
        }
    }
}
