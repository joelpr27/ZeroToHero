using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public int speed;
    public int jumpForce;

    private bool isGrounded = false;
    
    void Start()
    {
        isGrounded = false;
    }

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        //float moveVertical = Input.GetAxis ("Vertical");

        transform.Translate(new Vector2(moveHorizontal * speed, 0)* Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Debug.Log("Jump");

            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
        }
        
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            Debug.Log("Suelo");
            
            isGrounded = true;
        }   
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            Debug.Log("Aire");

            isGrounded = false;
        }
    }
}
