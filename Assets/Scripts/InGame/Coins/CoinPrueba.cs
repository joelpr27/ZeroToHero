
using UnityEngine;

public class CoinPrueba : MonoBehaviour
{
    private LevelInfo gameManager;
    public GameObject particle;

    private void Start()
    {
        gameManager=GameObject.Find("LevelInfo").GetComponent<LevelInfo>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.ScoreCoin();
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
