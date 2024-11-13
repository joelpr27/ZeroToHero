using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnemyDetect : MonoBehaviour
{
    public ArcherEnemy aE;

    [Header("Targget")]
    public string detectTag = "Player";

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(detectTag))
        {
            aE.isPlayerDetected = true;

            Debug.Log("PalyerIsInRange");


        }
    }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(detectTag))
        {
            aE.isPlayerDetected = false;

            Debug.Log("PalyerIsInRange");
        }
    }
}
