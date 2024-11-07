using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowEnemy : MonoBehaviour
{
    private GameManager gm;

    [Header("Targget")]
    public Player player;
    [Space]
    
    [Header("Move")]
    public float speed;
    [Space]

    [Header("Particle")]
    public GameObject particle;
    

    public void StunPlayer()
    {
        player.playerIsStunning = true;

        Debug.Log("A");
    }

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        transform.Translate(new Vector2(-speed, 0)* Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Instantiate(particle, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }

        if(other.tag == "Attack")
        {
            
            Instantiate(particle, transform.position, Quaternion.identity);
            Instantiate(particle, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
