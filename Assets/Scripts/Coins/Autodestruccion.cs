using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestruccion : MonoBehaviour
{
    public void Autodestruir()
    {
        Destroy(this.gameObject);
    }
}
