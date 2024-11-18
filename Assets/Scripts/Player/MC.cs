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

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }
}
