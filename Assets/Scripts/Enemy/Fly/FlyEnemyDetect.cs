using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyDetect : MonoBehaviour
{
    public FlyEnemy fE;

    public string detectTag = "Player";

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(detectTag))
        {
            fE.isPlayerDetected = true;

            Debug.Log("PalyerIsInRange");
        }
    }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(detectTag))
        {
            fE.isPlayerDetected = false;

            Debug.Log("PalyerIsInRange");
        }
    }
}
