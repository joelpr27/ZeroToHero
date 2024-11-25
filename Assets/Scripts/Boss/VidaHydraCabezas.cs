using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VidaHydraCabezas : MonoBehaviour
{

    public GameObject cuerpoHydra;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Attack")
        {
            Debug.Log("Golpe Cabeza");
            cuerpoHydra.GetComponent<VidaHydra>().GolpeCabeza();
        }
    }


}
