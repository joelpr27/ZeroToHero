using System.Collections;
using System.Collections.Generic;
using Mirror;
using Unity.VisualScripting;
using UnityEngine;

public class Palanca : NetworkBehaviour
{
    public Animator animator;

    public List<Puerta> puertas;

    [SyncVar]public bool activeLever = false;
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Attack")
        {
            CmdActivarPalanca();
        }	
    }

    /* [Command(requiresAuthority = false)] */
    private void CmdActivarPalanca()
    {
        activeLever = !activeLever;
        OpenDoor();
        if(activeLever)
        {
            Debug.Log(activeLever);
            LeverAnimActive();
        }
        else
        {
            Debug.Log(activeLever);
            LeverAnimDeactive();
        }
    }

    [ClientRpc]
    public void OpenDoor()
    {
        foreach(Puerta puerta in puertas)
        {
            puerta.IsOpen = !puerta.IsOpen;
        }
    }

    [ClientRpc]
    public void LeverAnimActive()
    {
        animator.SetBool("Active", true);
    }

    [ClientRpc]
    public void LeverAnimDeactive()
    {
        animator.SetBool("Active", false);
    }
}