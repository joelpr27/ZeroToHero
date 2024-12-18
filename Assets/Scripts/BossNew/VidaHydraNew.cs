using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaHydraNew : MonoBehaviour
{
    public GameObject hydra;
    public GameObject impactoCabeza;

    [Header("Vida")]
    public int enemyHealth = 1;
    public int currentEnemyHealth;
    public bool mitadVida = false;

    private bool dosTerceras = false;
    private bool unTercio = false;

    [Header("Particulas")]
    public ParticleSystem particle;
    public GameObject explosion;

    public GameObject explosionUbicacion;
    public ParticleSystem humo;


    [Header("Muñecas")]
    public GameObject muñeca1;
    public GameObject muñeca2;
    public GameObject muñeca3;




    // Start is called before the first frame update
    void Start()
    {
        particle.Stop();
        humo.Stop();

        currentEnemyHealth = enemyHealth;

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void RecibirDaño()
    {
        if (currentEnemyHealth > 0)
        {
            particle.Play();
            currentEnemyHealth--;

        }



        if (currentEnemyHealth <= (enemyHealth / 2) && mitadVida == false)
        {
            Debug.Log("MITAD VIDA");
            mitadVida = true;
            humo.Play();
        }

        if (!dosTerceras && currentEnemyHealth <= (enemyHealth * 2 / 3) && currentEnemyHealth > (enemyHealth * 1 / 3))
        {
            Debug.Log("Muñeca: 2/3 de vida");
            dosTerceras = true;

            SoltarMuñecas(1);
        }
        else if (!unTercio && currentEnemyHealth <= (enemyHealth * 1 / 3) && currentEnemyHealth > 0)
        {
            Debug.Log("Muñeca: 1/3 de vida");
            unTercio = true;

            SoltarMuñecas(2);
        }

        if (currentEnemyHealth <= 0)
        {
            hydra.GetComponent<PeleaNew>().muerte = true;
        }
    }

    public void ActivarImpactoCabeza()
    {
        impactoCabeza.SetActive(true);
    }

    public void DesactivarImpactoCabeza()
    {
        impactoCabeza.SetActive(false);
    }

    public void MuerteHydra()
    {
        SoltarMuñecas(3);

        Instantiate(explosion, explosionUbicacion.transform.position, Quaternion.identity);
        Destroy(hydra);


    }

    public void SoltarMuñecas(int muñeca)
    {
        if (muñeca == 1 && muñeca1 != null)
        {
            Debug.Log("Muñeca 1");

            Animator animatorMuñeca1 = muñeca1.GetComponent<Animator>();
            animatorMuñeca1.SetBool("L_Largo", true);

        }
        if (muñeca == 2 && muñeca2 != null)
        {
            Debug.Log("Muñeca 2");

            Animator animatorMuñeca2 = muñeca2.GetComponent<Animator>();
            animatorMuñeca2.SetBool("L_Corto", true);

        }
        if (muñeca == 3 && muñeca3 != null)
        {
            Debug.Log("Muñeca 3");

            Animator animatorMuñeca3 = muñeca3.GetComponent<Animator>();
            animatorMuñeca3.SetBool("L_Suelo", true);

        }
    }
}
