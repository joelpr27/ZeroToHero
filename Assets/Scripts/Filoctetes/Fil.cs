using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fil : MonoBehaviour
{
    enum State { Idle, Escribiendo, Celebrando };
    public Animator animator;

    public bool celebrando;
    int estadoActual = 0;
    State state;
    private Transform jugador;


    // Start is called before the first frame update
    void Start()
    {
        GameObject objetoJugador = GameObject.FindWithTag("Player");

        if (objetoJugador != null)
        {
            jugador = objetoJugador.transform;
        }
        else
        {
            Debug.LogWarning("No se encontró un objeto con el tag Player");
        }

        animator = GetComponent<Animator>();
        state = State.Idle;
        StartCoroutine(StateAleatorio());

    }

    // Update is called once per frame
    void Update()
    {

        switch (state)
        {
            case State.Idle:
                if (estadoActual == 1)
                {
                    state = State.Escribiendo;
                }
                else if (estadoActual == 2)
                {
                    state = State.Celebrando;
                }

                break;
            case State.Escribiendo:
                if (estadoActual == 0)
                {
                    state = State.Idle;
                }
                else if (estadoActual == 2)
                {
                    state = State.Celebrando;
                }
                break;
            case State.Celebrando:

                break;


        }


        switch (state)
        {
            case State.Idle:
                //Aplica la animacion (Tiene que tener el mismo nombre que en el animator)
                animator.SetInteger("State", 0);

                //Abrir posibles mecanicas

                break;

            case State.Escribiendo:
                //Aplica la animacion (Tiene que tener el mismo nombre que en el animator)
                animator.SetInteger("State", 1);

                //Abrir posibles mecanicas

                break;

            case State.Celebrando:
                //Aplica la animacion (Tiene que tener el mismo nombre que en el animator)
                animator.SetBool("celebrando", true);

                //Abrir posibles mecanicas

                break;

        }

        if (celebrando == true)
        {
            animator.SetBool("celebrando", true);
        }

        if (jugador.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
    }


    IEnumerator StateAleatorio()
    {
        yield return new WaitForSeconds(5);
        estadoActual = Random.Range(0, 2);
        Debug.Log(estadoActual);
        StartCoroutine(StateAleatorio());

    }
}
