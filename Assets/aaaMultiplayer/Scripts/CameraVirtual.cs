using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Cinemachine;

public class CameraVirtual : NetworkBehaviour
{
    private CinemachineVirtualCamera camera;
    private CinemachineVirtualCamera camera2;

    void Start()
    {
        camera = GameObject.Find("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
        camera2 = GameObject.Find("VirtualCamera2").GetComponent<CinemachineVirtualCamera>();

        GetCamera();
    }

    public void GetCamera()
    {
        if(isLocalPlayer)
        {
            camera.Follow = gameObject.transform;
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAA");
        }
        else
        {
            Debug.Log("EEEEEEEEEEEEEEEEEEEEEEEEEE");
            camera2.Follow = gameObject.transform;
        }
    }
}
