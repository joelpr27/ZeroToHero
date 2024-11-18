using UnityEngine;
using UnityEngine.Animations;

public class StatesMC : MC
{
    [Header("Maquina de estados")]
    public States mcState;
    public enum States{Idle, Run, Jump, Attack};    
    
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
                if (rb.velocity.y != 0.0f)
                {
                    mcState = States.Jump;
                }
                else if (rb.velocity.x != 0.0f && rb.velocity.y == 0.0f)
                {
                    mcState = States.Run;
                }
                else if (Input.GetKeyDown("j"))
                {
                    mcState = States.Attack;
                }
                break;

            case States.Run:
                if (rb.velocity.y != 0.0f)
                {
                    mcState = States.Jump;
                }
                else if (rb.velocity.x == 0.0f && rb.velocity.y == 0.0f)
                {
                    mcState = States.Idle;
                }
                else if (Input.GetKeyDown("j"))
                {
                    mcState = States.Attack;
                }
                break;

            case States.Jump:
                if (rb.velocity.x == 0.0f && rb.velocity.y == 0.0f)
                {
                    mcState = States.Idle;
                }
                else if (rb.velocity.x != 0.0f && rb.velocity.y == 0.0f)
                {
                    mcState = States.Run;
                }
                else if (Input.GetKeyDown("j"))
                {
                    mcState = States.Attack;
                }
                break;

            case States.Attack:
                if (rb.velocity.x == 0.0f && rb.velocity.y == 0.0f)
                {
                    mcState = States.Idle;
                }
                else if (rb.velocity.x != 0.0f && rb.velocity.y == 0.0f)
                {
                    mcState = States.Run;
                }
                if (rb.velocity.y != 0.0f)
                {
                    mcState = States.Jump;
                }
                break;
        }
    }
}
