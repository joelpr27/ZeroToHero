using System.Collections;
using System.Collections.Generic;
using Mirror;
using Unity.VisualScripting;
using UnityEngine;

public class Palanca : NetworkBehaviour
{
    public Animator animator;

    public List<Puerta> puertas;

    private bool activeLaver = false;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            CmdActivarPalanca();
        }	
    }

    [Command(requiresAuthority = false)]
    private void CmdActivarPalanca()
    {
        activeLaver = !activeLaver;
        foreach(Puerta puerta in puertas)
        {
            puerta.IsOpen = !puerta.IsOpen;
        }
        if(activeLaver)
        {
            LaverAnimActive();
        }
        else
        {
            LaverAnimDesactive();
        }
    }

    [ClientRpc]
    public void LaverAnimActive()
    {
        animator.SetBool("Active", true);
    }

    [ClientRpc]
    public void LaverAnimDesactive()
    {
        animator.SetBool("Active", false);
    }
}