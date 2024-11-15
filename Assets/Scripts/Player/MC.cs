using UnityEngine;
/// <summary>
/// Root of the character program, grants acces to the components of the object.
/// </summary>
public class MC : MonoBehaviour
{
    /* [HideInInspector] */ public Rigidbody2D rb;
   /*  [HideInInspector]  */public Animator anim;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }
}
