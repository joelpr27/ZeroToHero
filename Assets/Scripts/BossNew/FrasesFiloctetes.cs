using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrasesFiloctetes : MonoBehaviour
{
    [Header("Configuración")]
    public string[] frases; // Lista de frases que el personaje puede decir
    public float intervaloMin = 5f; // Tiempo mínimo entre frases
    public float intervaloMax = 10f; // Tiempo máximo entre frases

    private float tiempoSiguienteFrase;

    void Start()
    {
        // Configurar el tiempo para la primera frase
        tiempoSiguienteFrase = Time.time + Random.Range(intervaloMin, intervaloMax);
    }

    void Update()
    {
        // Verificar si es momento de decir una frase
        if (Time.time >= tiempoSiguienteFrase)
        {
            DecirFrase();
            // Configurar el tiempo para la siguiente frase
            tiempoSiguienteFrase = Time.time + Random.Range(intervaloMin, intervaloMax);
        }
    }

    void DecirFrase()
    {
        if (frases.Length == 0) return; // Si no hay frases, no hacer nada

        // Seleccionar una frase al azar
        int indiceAleatorio = Random.Range(0, frases.Length);
        string fraseSeleccionada = frases[indiceAleatorio];

        // Mostrar la frase (puedes adaptarlo a tu sistema de diálogo)
        Debug.Log(fraseSeleccionada);

        // Aquí podrías conectar esto con un sistema de UI o un sonido
        // Ejemplo: Mostrar en pantalla
        // UIManager.Instance.MostrarTexto(fraseSeleccionada);
    }
}
