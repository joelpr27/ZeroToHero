using UnityEngine;
/// <summary>
/// Root of the character program, grants acces to the components of the object.
/// </summary>
public class MC : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Header("Inputs")]
    public string punch;
    public string powerUpAttack;
    public string powerUpMovement;

    [Header("PowerUps's")]
    public bool HermesPowerUpOn;
    public bool IrisPowerUpOn;
    public bool AtlasPowerUpOn;
    public bool ZeusPowerUpOn;

    [Header("Attack Triggers")]
    public GameObject DamageTrigger;
    public BoxCollider2D LigtningTrigger;


    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        punch = "Fire1";
        powerUpAttack = "Fire2";
        powerUpMovement = "Fire3";
    }

    public void DamageOn()
    {
        DamageTrigger.SetActive(true);
    }
    public void DamageOff()
    {
        DamageTrigger.SetActive(false);
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    
}
