using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class MostrarPowerUps : MonoBehaviour
{
    public GameObject GM;
    public bool movimiento;
    public bool ataque;

    public Sprite[] Sprites;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ataque == true && GM.GetComponent<GameManager>().IsRock)
        {
            // gameObject.GetComponent<Image>().sprite = Sprites[0];
        }
        else if (ataque == true && GM.GetComponent<GameManager>().IsLightPU)
        {
            // gameObject.GetComponent<Image>().sprite = Sprites[1];
        }


        if (movimiento == true && GM.GetComponent<GameManager>().IsDobleJump)
        {
            // gameObject.GetComponent<Image>().sprite = Sprites[3];
        }
        else if (movimiento == true && GM.GetComponent<GameManager>().IsDash)
        {
            // gameObject.GetComponent<Image>().sprite = Sprites[4];
        }
    }
}
