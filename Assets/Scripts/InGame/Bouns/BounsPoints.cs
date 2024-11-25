
using UnityEngine;

public class BounsPoints : MonoBehaviour
{
    private LevelInfo LI;

    public GameObject particle;
    void Start()
    {
        LI = GameObject.Find("LevelInfo").GetComponent<LevelInfo>();
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("A");
            
            Instantiate(particle, transform.position, Quaternion.identity);
            Instantiate(particle, transform.position, Quaternion.identity);
            LI.BonusPointsLI();
            LI.bounsPoints++;
            Destroy(gameObject);
        }
    }
}
