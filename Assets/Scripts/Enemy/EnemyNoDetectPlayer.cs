using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNoDetectPlayer : MonoBehaviour
{
    public MeleeEnemy mE;

    public string detectTag = "Player";

    /* public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(detectTag))
        {
            mE.isPlayerDetected = true;

            Debug.Log("PalyerIsInRange");
        }
    } */
    
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(detectTag))
        {
            mE.isPlayerDetected = false;

            Debug.Log("PalyerIsInRange");
        }
    }
}
