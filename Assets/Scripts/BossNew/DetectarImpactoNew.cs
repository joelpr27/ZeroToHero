
using UnityEngine;

public class DetectarImpactoNew : MonoBehaviour
{
    public GameObject hydra;
    public GameObject zona;


    void OnTriggerEnter2D(Collider2D other)
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

                hydra.GetComponent<PeleaNew>().impactoAtaque = true;

            }
            else if (zona.name == "ImpactoFuego")
            {
                Debug.Log("IMPACTO Fuego");
            }
        }
    }




}
