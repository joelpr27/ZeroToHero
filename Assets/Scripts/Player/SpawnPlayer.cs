using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    private CameraManager cameraM;
    public GameObject spawnPoint;
    public GameObject camara;
    void Start()
    {
        gameObject.transform.position = spawnPoint.transform.position;
        camara.transform.position = spawnPoint.transform.position + cameraM.offset;
    }
}
