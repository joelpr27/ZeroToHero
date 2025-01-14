using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    protected LevelInfo LI;
    public GameObject BaseObject;
    private GameManager gameManager;
    

    [Header("Helth")]
    public int enemyHealth = 1;
    public int currentEnemyHealth;

    public GameObject particle;
    [Space]

    [Header("Animaciones")]
    public AudioSource audioSource;

    public void GetDamage() {
        /* audioSource.volume = gameManager.volumeSlider.value; */
        if (currentEnemyHealth > 0)
            {
                StartCoroutine(RedBlink());
                
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

    IEnumerator RedBlink()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;

        yield return new WaitForSeconds(0.07f);

        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
