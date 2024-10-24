using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DetectPlayerAttack : MonoBehaviour
{
    public EnemyAttack ea;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            Debug.Log("a");

            ea.playerInSigth = true;

            Debug.Log("PalyerIsInRange");
        } 
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            ea.playerInSigth = false;

            Debug.Log("PalyerIsNotInRange");
        }
    }

}
