
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    float time = 3.0f;

    public float respawn;

    public GameObject Enemy;

    void Start()
    {
        time = 0.0f;
    }

    void Update()
    {
        time -= Time.deltaTime;

        if(time <= 0)
        {
            Instantiate(Enemy, transform.position, Quaternion.identity);

            time = respawn;
        }
    }
}
