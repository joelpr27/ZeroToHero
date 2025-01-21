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
    
    public LayerMask fakeGroundLayer;


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

    
    public AudioSource audioPegar;
    public AudioSource audioDash;
    public AudioSource audioJump;
    public AudioSource audioRock;
    public AudioSource audioHit;
    public AudioSource rayo1;
    public AudioSource rayo2;


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

    public void PunchSound()
    {
        float rpitch = Random.Range(1f, 2f);
        audioPegar.pitch=rpitch;
        audioPegar.Play();
    }

    public void DashSound()
    {
        audioDash.Play();
    }

    public void JumpSound()
    {
        audioJump.Play();
    }

    public void RockSound()
    {
        audioRock.Play();
    }

    public void HitSound()
    {
        audioHit.Play();
    }

    public void Rayo1()
    {
        rayo1.Play();
    }

    public void Rayo2()
    {
        rayo2.Play();
    }

    public bool IsGrounded()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer) || Physics2D.OverlapCircle(groundCheck.position, 0.1f, fakeGroundLayer))
        {
            return true;
        }

        return false;
    }

    
}
