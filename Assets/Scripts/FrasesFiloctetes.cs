using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FrasesFiloctetes : MonoBehaviour
{
    enum State { Idle, In, Out };

    [Header("Configuración")]

    public Animator animator;

    public TMP_Text textFrases;
    public string[] frases_Lvl1;
    public string[] frases_Lvl2;
    public string[] frases_Lvl3;

    public string[] frases_LvlHydra;


    private float tiempoSiguienteFrase;

    void Start()
    {

        frases_LvlHydra = new string[] {
        "No es un consejo bueno para una hydra de verdad pero a esta dale en la CABEZA!!!",
        };


    }

    void Update()
    {
    }

    public void ActivarCuadroTexto(string Lvl, int frase)
    {
        Debug.Log("ActivarCuadroTexto");

        animator.SetInteger("State", 1);

        if (Lvl == "Lvl1")
        {
            textFrases.text = frases_Lvl1[frase];
        }
        else if (Lvl == "Lvl2")
        {
            textFrases.text = frases_Lvl2[frase];
        }
        else if (Lvl == "Lvl3")
        {
            textFrases.text = frases_Lvl3[frase];
        }
        else if (Lvl == "LvlHydra")
        {
            textFrases.text = frases_LvlHydra[frase];
        }

        StartCoroutine(DesactivarCuadroTexto());

    }

    IEnumerator DesactivarCuadroTexto()
    {
        Debug.Log("DesactivarCuadroTexto");

        yield return new WaitForSeconds(5);
        animator.SetInteger("State", 2);
    }

}
