using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public GameObject target;

    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y + 2.0f, -10.0f);
        transform.position = newPos;
    }

}
