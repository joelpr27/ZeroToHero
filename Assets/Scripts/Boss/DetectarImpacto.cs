
using UnityEngine;

public class DetectarImpacto : MonoBehaviour
{
    public GameObject hydra;
    public GameObject zona;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ComprobarImpacto(other);
        }
    }

    public void ComprobarImpacto(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (zona.name == "ImpactoZarpa")
            {
                Debug.Log("IMPACTO Zarpa");
            }
            else if (zona.name == "ImpactoMordisco")
            {
                Debug.Log("IMPACTO Mordisco");

                hydra.GetComponent<Pelea>().ImpactarMordisco();

            }
            else if (zona.name == "ImpactoFuego")
            {
                Debug.Log("IMPACTO Fuego");
            }
        }
    }



}
