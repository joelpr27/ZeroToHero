using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private GameManager gm; 

    public int enemyHealth = 1;
    public int currentEnemyHealth;

    public GameObject particle;   

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        currentEnemyHealth = enemyHealth;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Attack")
        {
            if(currentEnemyHealth > 0)
            {
                Instantiate(particle, transform.position, Quaternion.identity);
                currentEnemyHealth--;
            }
            if(currentEnemyHealth <= 0)
            {
                Instantiate(particle, transform.position, Quaternion.identity);
                Instantiate(particle, transform.position, Quaternion.identity);
                gm.Score();
                Destroy(gameObject);
            }
        }
    }
}
