using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GuardarPartida : MonoBehaviour
{
    public DatosGuardado datosGuardado = new DatosGuardado(); 
    string dataPath;

    public void Awake()
    {
        dataPath = Application.persistentDataPath + "/HerculesDatosGuardado.json";  
    }
    
    
    public void Update()
    {
        //improvisado para debug
        if (Input.GetKeyDown("p"))
        {
            GuardarJSON();
        }
        if (Input.GetKeyDown("l"))
        {
            CargarJSON();
        }
    }


    public void GuardarJSON()
    {
        string datos = JsonUtility.ToJson(datosGuardado);
        System.IO.File.WriteAllText(dataPath, datos);
    }

    public void CargarJSON()
    {
        string datos =  System.IO.File.ReadAllText(dataPath);
        datosGuardado = JsonUtility.FromJson<DatosGuardado>(datos);
    }

}
[System.Serializable]
public class DatosGuardado{
    //Añadir todo lo que tengamos que guardar como vatiables (constructor)
    public float puntosNivel1;
}