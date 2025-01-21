using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FrasesFilUI : MonoBehaviour
{
    public GameObject bocadillo;
    public Animator animator;
    public string[] frases;
    public TMP_Text textFrases;

    // Start is called before the first frame update
    void Start()
    {
        frases = new string[] {
            "¡Vamos, piernas de gelatina! Hasta un caracol te ganaria en una carrera.",
            "¿En serio? Hasta mi abuela con artritis esquivaria mejor que eso.",
            "¡Dale mas fuerte! ¡No estas acariciando un gatito, estas peleando!",
            "¿Eso fue un golpe o una caricia? Porque la hydra ni se inmuto.",
            "¡Vamos, heroe! ¡Mueve esos musculos de adorno antes de que te conviertan en papilla!",
            "Si sigues asi, mejor empiezo a escribir tu epitafio...",
            "¡Por Zeus! ¡He entrenado a vacas mas ágiles que tu!",
            "¿Necesitas un mapa para encontrar la cabeza de la hydra? ¡Apunta bien, campeon!",
            "Si el Olimpo viera esto, te mandarian de vuelta a limpiar establos.",
            "¡No puedes fallar tanto! ¡Hasta un ciclope con un parche veria mejor que tu!"
        };

    }

    public void AñadirFrase()
    {
        textFrases.text = frases[NumeroAleatorio()];

    }

    public void QuitarFrase()
    {
        textFrases.text = "";
    }

    public int NumeroAleatorio()
    {
        return Random.Range(0, frases.Length);
    }

}
