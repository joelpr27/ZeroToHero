using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Transform cameraTransform;  // Referencia a la cámara
    public Vector2 parallaxMultiplier;  // Velocidad de movimiento de esta capa en relación al movimiento de la cámara

    private Vector3 lastCameraPosition;

    void Start()
    {
        // Al iniciar, registra la posición inicial de la cámara
        lastCameraPosition = cameraTransform.position;
    }

    void Update()
    {
        // Calcula cuánto se ha movido la cámara desde el último frame
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

        // Mueve el fondo según el multiplicador de parallax
        transform.position += new Vector3(deltaMovement.x * parallaxMultiplier.x, deltaMovement.y * parallaxMultiplier.y, 0);

        // Actualiza la posición anterior de la cámara
        lastCameraPosition = cameraTransform.position;
    }
}
