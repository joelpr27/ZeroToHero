using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("Movement")]
    float moveHorizontal;
    public int speed;
    public int jumpForce;
    private bool isGrounded = false;
    [Space]

    [Header("Combat")]
    public GameObject myAttack;
    [Space]

    [Header("Stun")]
    public bool playerIsStunning = false;
    public float stunTime;
    public float currentStunTime;
    
#region Movement
    public void Movement()
    {
        moveHorizontal = Input.GetAxis ("Horizontal");

        transform.Translate(new Vector2(moveHorizontal * speed, 0)* Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Debug.Log("Jump");

            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
        }

        Orientacion();
    }

    void Orientacion()
    {
        if(moveHorizontal > 0)
        {
            gameObject.transform.localScale = new Vector2(1, 1);
        }
        if(moveHorizontal < 0)
        {
            gameObject.transform.localScale = new Vector2(-1, 1);
        }
    }

    public void Stun()
    { 
        currentStunTime += Time.deltaTime;

        playerIsStunning = true;

        if(currentStunTime >= stunTime)
        {
            currentStunTime = 0;

            playerIsStunning = false;
        }
        Debug.Log("Stun");
    }
#endregion

#region Combat
    public void Attack()
    {
        //se tiene que hacer un cooldown
        if(Input.GetMouseButton(0))
        {
            myAttack.SetActive(true);
        }
        else
        {
            myAttack.SetActive(false);
        }
    }
#endregion

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        isGrounded = false;
        myAttack.SetActive(false);

        playerIsStunning = false;
        currentStunTime = 0;
    }

    void Update()
    {
        if(playerIsStunning == true)
        {
            Stun();
        }
        else
        {
            Movement();
            
            Attack();
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "EnemyAttack")
        {
            playerIsStunning = true;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == ("Ground"))
        {
            Debug.Log("Suelo");
            
            isGrounded = true;
        }   
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == ("Ground"))
        {
            Debug.Log("Aire");

            isGrounded = false;
        }
    }
}
