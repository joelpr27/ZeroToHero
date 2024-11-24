using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public Transform targetObject;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(targetObject.position.x, targetObject.position.y + 2.0f, -10.0f);
        transform.position = newPos;
    }

}
