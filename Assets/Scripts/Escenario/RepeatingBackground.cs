using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private float textureUnitSizeX;  // Tamaño del sprite en el eje X (ancho)

    void Start()
    {
        // Calcula el tamaño del sprite en unidades del mundo
        textureUnitSizeX = GetComponent<SpriteRenderer>().sprite.texture.width / GetComponent<SpriteRenderer>().sprite.pixelsPerUnit * transform.localScale.x;
    }

    void Update()
    {
        float cameraX = Camera.main.transform.position.x;
        float offset = cameraX - transform.position.x;

        // Reposiciona el fondo si ha salido de la vista de la cámara
        if (Mathf.Abs(offset) >= textureUnitSizeX)
        {
            transform.position += new Vector3(Mathf.Sign(offset) * textureUnitSizeX * 2f, 0, 0);
        }
    }
}
