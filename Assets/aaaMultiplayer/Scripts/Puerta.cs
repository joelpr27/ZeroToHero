using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Mirror;
using UnityEngine;
using UnityEngine.UIElements;

public class Puerta : NetworkBehaviour
{
    public Transform posUp;
    public Transform posDown;

    public float speed;
    private Vector2 target;

    [SyncVar]public bool IsOpen;

    void Start()
    {
        if(IsOpen)
        {
            transform.position = posUp.position;
        }
        else
        {
            transform.position = posDown.position;
        }
    }

    void Update()
    {
        if(IsOpen)
        {
            target = posUp.position;
        }
        else
        {
            target = posDown.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
