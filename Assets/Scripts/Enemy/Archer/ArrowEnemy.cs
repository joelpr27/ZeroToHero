using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowEnemy : MonoBehaviour
{
    [Header("Move")]
    public float speed;
    [Space]
    public float delateTime;
    private float currentDelateTime;
    [Space]

    [Header("Particle")]
    public GameObject particle;

    void Start()
    {
        currentDelateTime = 0;
    }

    void Update()
    {
        transform.Translate(new Vector2(-speed, 0)* Time.deltaTime);

        currentDelateTime += Time.deltaTime;

        if(currentDelateTime >= delateTime)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" || other.tag == "Ground")
        {
            Instantiate(particle, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
        
        Debug.Log(other.tag);
    }
}
