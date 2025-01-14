using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


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
            gameObject.GetComponent<UnityEngine.UI.Image>().sprite = Sprites[0];
            gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.white;

        }
        else if (ataque == true && GM.GetComponent<GameManager>().IsLightPU)
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().sprite = Sprites[1];
            gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.white;

        }
        else if (ataque == true && GM.GetComponent<GameManager>().IsRock == false && GM.GetComponent<GameManager>().IsLightPU == false)
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.clear;
        }


        if (movimiento == true && GM.GetComponent<GameManager>().IsDobleJump)
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().sprite = Sprites[2];
            gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.white;

        }
        else if (movimiento == true && GM.GetComponent<GameManager>().IsDash)
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().sprite = Sprites[3];
            gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.white;

        }
        else if (movimiento == true && GM.GetComponent<GameManager>().IsDobleJump == false && GM.GetComponent<GameManager>().IsDash == false)
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.clear;
        }
    }
}
