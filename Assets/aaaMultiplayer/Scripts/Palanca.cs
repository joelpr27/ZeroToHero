using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Palanca : MonoBehaviour
{
    public Animator animator;

    public List<Puerta> puertas;
    
    public void LaverAnimActive()
    {
        animator.SetBool("Active", true);
        animator.SetBool("Desactive", false);
    }

    public void LaverAnimDesactive()
    {
        animator.SetBool("Desactive", true);
        animator.SetBool("Active", true);
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            foreach(Puerta puerta in puertas)
            {
                puerta.IsOpen = !puerta.IsOpen;
                //puerta.MoveDoor();
                Debug.Log(puerta.IsOpen);
            }
        }	
    }
}
