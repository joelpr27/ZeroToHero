using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    public Vector3 offset;
    public float damping;

    public GameObject target;

    public Vector3 vel = Vector3.zero;

    void Start()
    {
        

        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10);
    }

    void FixedUpdate()
    {
        target = GameObject.FindWithTag("Player");
        Vector3 targetPosition = target.transform.position + offset;
        targetPosition.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, damping);
    }
}
