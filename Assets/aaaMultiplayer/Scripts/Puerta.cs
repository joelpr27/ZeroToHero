using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class Puerta : MonoBehaviour
{
    public Transform posUp;
    public Transform posDown;

    public float speed;
    private Vector2 target;

    public bool IsOpen;


    /* public void MoveDoor()
    {
        if(IsOpen)
        {
            if(transform.position != finalPos)
            {
                transform.Translate(Vector3.up * 4);
            }
            //transform.localPosition = new Vector2(transform.localPosition.x, finalPos);
        }
        else
        {
            if(transform.position.y != initialPos)
            {
                transform.Translate(Vector3.down * 4);
            }
            
            //transform.localPosition = new Vector2(transform.localPosition.x, initialPos);
        }
    } */

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
