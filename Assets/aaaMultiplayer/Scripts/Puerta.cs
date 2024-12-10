using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class Puerta : MonoBehaviour
{
    public int initialPos;
    public int finalPos;

    public bool IsOpen;

    // Update is called once per frame
    void Update()
    {
        if(IsOpen)
        {
            transform.Translate(Vector3(transform.localPosition.x, transform.localPosition.y + finalPos, 0), initialPos);
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + finalPos);
        }
        else
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + initialPos);
        }
    }
}
