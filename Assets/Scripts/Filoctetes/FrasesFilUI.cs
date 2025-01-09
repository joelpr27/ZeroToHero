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
        "¡Vamos, piernas de gelatina! Hasta un caracol te ganaría en una carrera.",
        "¿En serio? Hasta mi abuela con artritis esquivaría mejor que eso.",
        "¡Dale más fuerte! ¡No estás acariciando un gatito, estás peleando!",
        "¿Eso fue un golpe o una caricia? Porque la hydra ni se inmutó.",
        "¡Vamos, héroe! ¡Mueve esos músculos de adorno antes de que te conviertan en papilla!",
        "Si sigues así, mejor empiezo a escribir tu epitafio...",
        "¡Por Zeus! ¡He entrenado a vacas más ágiles que tú!",
        "¿Necesitas un mapa para encontrar la cabeza de la hydra? ¡Apunta bien, campeón!",
        "Si el Olimpo viera esto, te mandarían de vuelta a limpiar establos.",
        "¡No puedes fallar tanto! ¡Hasta un cíclope con un parche vería mejor que tú!"
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
