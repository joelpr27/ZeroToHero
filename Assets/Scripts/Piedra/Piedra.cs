
using UnityEngine;

public class Rock : MonoBehaviour
{
    public string ParedTag = "ParedDestructible";
    public string SueloTag = "Ground";
    public string EnemyTag = "Enemy";
    public string AndamiosTag = "Andamios";
    public GameObject particle;
    public Vector2 launchForce;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        LaunchRock();
    }

    private void LaunchRock()
    {
        rb.AddForce(launchForce, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag(ParedTag))
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag(SueloTag))
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag(AndamiosTag))
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag(EnemyTag))
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
