using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stuned : MonoBehaviour
{
    public GameObject particle;
    public GameObject P_Cabeza;
    GameObject ParticulasCabeza;

    public GameObject P_Cuello1;
    GameObject ParticulasCuello1;

    public GameObject P_Cuello2;
    GameObject ParticulasCuello2;

    // Método para activar las partículas
    public void ActivarParticulas()
    {
        Debug.Log("Activa Particulas Hydra");

        ParticulasCabeza = Instantiate(particle, P_Cabeza.transform.position, Quaternion.identity);
        ParticulasCuello1 = Instantiate(particle, P_Cuello1.transform.position, Quaternion.identity);
        ParticulasCuello2 = Instantiate(particle, P_Cuello2.transform.position, Quaternion.identity);


        // Ajusta el orden en la capa
        ParticleSystemRenderer renderer_ParticulasCabeza = ParticulasCabeza.GetComponent<ParticleSystemRenderer>();
        ParticleSystemRenderer renderer_ParticulasCuello1 = ParticulasCuello1.GetComponent<ParticleSystemRenderer>();
        ParticleSystemRenderer renderer_ParticulasCuello2 = ParticulasCuello2.GetComponent<ParticleSystemRenderer>();

        if (renderer_ParticulasCabeza != null && renderer_ParticulasCuello1 != null && renderer_ParticulasCuello2 != null)
        {
            renderer_ParticulasCabeza.sortingOrder = 999;
            renderer_ParticulasCuello1.sortingOrder = 999;
            renderer_ParticulasCuello2.sortingOrder = 999;

        }
    }

    // Método para detener las partículas
    public void DesactivarParticulas()
    {
        Debug.Log("Desactiva Particulas Hydra");

        Destroy(ParticulasCabeza);
        Destroy(ParticulasCuello1);
        Destroy(ParticulasCuello2);


    }
}

