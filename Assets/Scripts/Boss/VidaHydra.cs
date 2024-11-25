using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VidaHydra : MonoBehaviour
{
    private LevelInfo LI;

    public GameObject hydra;



    [Header("Helth")]
    public int enemyHealth = 1;
    public int currentEnemyHealth;

    public GameObject particle;
    public GameObject explosion;
    public ParticleSystem humo;

    bool mitadVida = false;




    void Start()
    {
        LI = GameObject.Find("LevelInfo").GetComponent<LevelInfo>();
        humo.Stop();

        #region Death
        currentEnemyHealth = enemyHealth;
        #endregion

    }

    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Attack")
        {
            Debug.Log("Golpe Pecho");

            if (currentEnemyHealth > 0)
            {
                Instantiate(particle, transform.position, Quaternion.identity);
                currentEnemyHealth--;

            }
            if (currentEnemyHealth <= (enemyHealth / 2) && mitadVida == false)
            {
                Debug.Log("MITAD VIDA");
                mitadVida = true;
                humo.Play();
            }
            if (currentEnemyHealth <= 0)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Instantiate(explosion, transform.position, Quaternion.identity);
                // LI.ScoreHidra();
                Destroy(hydra);
            }
        }
    }

    public void GolpeCabeza()
    {
        if (currentEnemyHealth > 0)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            currentEnemyHealth--;

        }
        if (currentEnemyHealth <= (enemyHealth / 2) && mitadVida == false)
        {
            Debug.Log("MITAD VIDA");
            mitadVida = true;
            humo.Play();
        }
        if (currentEnemyHealth <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Instantiate(explosion, transform.position, Quaternion.identity);
            // LI.ScoreHidra();
            Destroy(hydra);
        }
    }

}
