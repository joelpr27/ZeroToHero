using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarPlayerNew : MonoBehaviour
{
    public GameObject hydra;
    public GameObject triggerFuego;
    public GameObject triggerMordisco;
    public GameObject triggerZarpa;



    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
    }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.tag == "Player")
    //     {
    //         hydra.GetComponent<PeleaNew>().ataque = 0;

    //         triggerFuego.SetActive(true);
    //         triggerMordisco.SetActive(true);
    //         triggerZarpa.SetActive(true);

    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player entro en " + tag);

            if (tag == "TriggerFuego")
            {
                Debug.Log("Fire Attack!");

                hydra.GetComponent<PeleaNew>().ataque = 3;
                DisableTriggers();
            }
            else if (tag == "TriggerMordisco")
            {
                Debug.Log("Bite Attack!");

                hydra.GetComponent<PeleaNew>().ataque = 2;
                DisableTriggers();

            }
            else if (tag == "TriggerZarpa")
            {
                Debug.Log("Claw Attack!");

                hydra.GetComponent<PeleaNew>().ataque = 1;
                DisableTriggers();

            }

        }
    }

    public void DisableTriggers()
    {
        triggerFuego.SetActive(false);
        triggerMordisco.SetActive(false);
        triggerZarpa.SetActive(false);
    }
}
