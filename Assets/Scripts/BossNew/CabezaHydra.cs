using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabezaHydra : MonoBehaviour
{
    public GameObject hydra;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Attack")
        {
            Debug.Log("Golpe Cabeza");
            hydra.GetComponent<VidaHydraNew>().RecibirDaño();
        }
    }

}
