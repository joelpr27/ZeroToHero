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
    public AudioSource enemyAudioSource;
    public AudioClip[] enemySounds;

    public GameObject[] Body;

    public void GetDamage() {
        //enemyAudioSource.pitch = Random.Range(0f,2f);

        if (currentEnemyHealth > 0)
            {
                StartCoroutine(RedBlink());
                enemyAudioSource.clip = enemySounds[0];
                enemyAudioSource.Play();

                Instantiate(particle, transform.position, Quaternion.identity);
                currentEnemyHealth--;
            }
            if (currentEnemyHealth <= 0)
            {
                enemyAudioSource.clip = enemySounds[1];
                enemyAudioSource.Play();
                Instantiate(particle, transform.position, Quaternion.identity);
                Instantiate(particle, transform.position, Quaternion.identity);
                LI.Score();
                
                StartCoroutine(Death());
            }

    }

    IEnumerator RedBlink()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;

        yield return new WaitForSeconds(0.07f);

        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    IEnumerator Death()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        foreach (var part in Body)
        {
            part.GetComponent<SpriteRenderer>().enabled = false;
        }
        yield return new WaitForSeconds(enemySounds[1].length);

        Destroy(BaseObject);
    }
}
