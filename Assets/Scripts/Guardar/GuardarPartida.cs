using System.IO;
using UnityEngine;

public class GuardarPartida : MonoBehaviour
{
    public DatosGuardado datosGuardado = new DatosGuardado(); 
    string dataPath;

    public void Awake()
    {
        string carpeta = Application.dataPath + "/CarpetaGuardados/";
        if (!Directory.Exists(carpeta))
        {
            // Crear la carpeta si no existe
            Directory.CreateDirectory(carpeta); 
            
            Debug.Log("Carpeta creada en: " + carpeta);
        }
        // Ruta completa del archivo
        dataPath = carpeta + "PuntosGuardados.json"; 
        // Intentar cargar al inicio 
        CargarJSON();
    }
    
    
    /* public void Update()
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
    } */


    public void GuardarJSON()
    {
        string datos = JsonUtility.ToJson(datosGuardado);
        System.IO.File.WriteAllText(dataPath, datos);

        Debug.Log("Guardado");
    }

    public void CargarJSON()
    {
        string datos =  System.IO.File.ReadAllText(dataPath);
        datosGuardado = JsonUtility.FromJson<DatosGuardado>(datos);

        Debug.Log("Cargado");
    }

}
[System.Serializable]
public class DatosGuardado{
    //Añadir todo lo que tengamos que guardar como vatiables (constructor)
    public float puntosNivel1 = 0;
    public float puntosNivel2 = 0;
    public float puntosNivel3 = 0;
    public float puntosNivelBoss = 0;
}