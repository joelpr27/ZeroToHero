using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPrueba : MonoBehaviour
{
    public int valor = 1;
    public CoinGameManager gameManager;
    public GameObject particle;

    private void Start()
    {
        gameManager=GameObject.FindWithTag("GameController").GetComponent<CoinGameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.SumarPuntos(valor);
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
