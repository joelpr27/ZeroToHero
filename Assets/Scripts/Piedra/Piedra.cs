using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Rock : MonoBehaviour
{
    public string ParedTag = "Pared destructible";  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ParedTag))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
