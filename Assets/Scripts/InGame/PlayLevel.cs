
using UnityEngine;

public class PlayLevel : MonoBehaviour
{
    private GameManager gm;
    private LevelInfo LI;
    
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        LI = GameObject.Find("LevelInfo").GetComponent<LevelInfo>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && gameObject.tag == "WinObject")
        {
            gm.areYouWinningSon = true;
        }

        if(other.tag == "Player" && gameObject.tag == "StartObject")
        {
            LI.starTimer = true;
        }
    }
}
