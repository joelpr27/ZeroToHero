using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    protected LevelInfo LI;
    public GameObject BaseObject;

    

    [Header("Helth")]
    public int enemyHealth = 1;
    public int currentEnemyHealth;

    public GameObject particle;

    public void GetDamage() {
        if (currentEnemyHealth > 0)
            {
                Instantiate(particle, transform.position, Quaternion.identity);
                currentEnemyHealth--;
            }
            if (currentEnemyHealth <= 0)
            {
                Instantiate(particle, transform.position, Quaternion.identity);
                Instantiate(particle, transform.position, Quaternion.identity);
                LI.Score();
                Destroy(BaseObject);
            }
    }
}
