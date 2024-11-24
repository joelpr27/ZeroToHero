
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public MeleeEnemy mE;

    public string detectTag = "Player";

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(detectTag))
        {
            mE.playerInSigth = true;

            Debug.Log("PalyerIsInRange");
        }
    }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(detectTag))
        {
            mE.playerInSigth = false;

            Debug.Log("PalyerIsInRange");
        }
    }
}
