
using System.Collections;
using UnityEngine;

public class DetectarPlayer : MonoBehaviour
{
    public GameObject hydra;
    public GameObject zona;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            TriggerActual(other);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ComprobarEsquive(other);
        }
    }

    //La hydra golpea en el trigger que ha detectado al player
    public void TriggerActual(Collider2D other)
    {
        if (other.tag == "Player")
        {
            hydra.GetComponent<Pelea>().Golpear(zona.name);

            if (zona.name == "TriggerZarpazo")
            {
                hydra.GetComponent<Pelea>().DesactivarTriggers("MF");
                StartCoroutine(DeactivarTriggers(3.30f));

            }
            else if (zona.name == "TriggerMordisco")
            {
                hydra.GetComponent<Pelea>().DesactivarTriggers("ZF");
                StartCoroutine(DeactivarTriggers(1.50f));

            }
            else if (zona.name == "TriggerFuego")
            {
                hydra.GetComponent<Pelea>().DesactivarTriggers("ZM");
                StartCoroutine(DeactivarTriggers(3.5f));

            }

        }

    }

    IEnumerator DeactivarTriggers(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);

        hydra.GetComponent<Pelea>().DesactivarTriggers("all");

    }

    public void ComprobarEsquive(Collider2D other)
    {
        if (other.tag == "Player")
        {

            if (zona.name == "TriggerZarpazo")
            {
                Debug.Log("ESQUIVE TriggerZarpazo");

                hydra.GetComponent<Pelea>().Esquive(4.2f);
            }
            if (zona.name == "TriggerMordisco")
            {
                Debug.Log("ESQUIVE TriggerZarpazo");

                hydra.GetComponent<Pelea>().Esquive(4.8f);
            }
            else if (zona.name == "TriggerFuego")
            {
                Debug.Log("ESQUIVE TriggerFuego");

                hydra.GetComponent<Pelea>().Esquive(4.8f);
            }
        }

    }




}
