using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeleaNew : MonoBehaviour
{
    enum State { Idle, Mordisco, Zarpazo, Fuego };

    public Animator animator;
    State state;

    [Header("Combate:")]
    public int ataque;
    public bool impactoAtaque;
    public int tiempoPrimerAtaque;
    public int tiempoEntreAtaques;
    public GameObject triggerCabezas;


    [Header("Triggers de Deteccion:")]
    public GameObject deteccionZarpa;
    public GameObject deteccionMordisco;
    public GameObject deteccionFuego;


    [Header("Triggers de Impacto:")]
    public GameObject impactoZarpa;
    public GameObject impactoMordisco;
    public GameObject impactoFuego;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

        switch (state)
        {
            case State.Idle:
                if (ataque == 1)
                {
                    state = State.Zarpazo;
                }
                else if (ataque == 2)
                {
                    state = State.Mordisco;
                }
                else if (ataque == 3)
                {
                    state = State.Fuego;
                }
                break;
            case State.Zarpazo:
                if (ataque == 0)
                {
                    state = State.Idle;
                }
                break;
            case State.Mordisco:
                if (ataque == 0)
                {
                    state = State.Idle;
                }
                break;
            case State.Fuego:
                if (ataque == 0)
                {
                    state = State.Idle;
                }
                break;

        }


        switch (state)
        {
            case State.Idle:
                //Aplica la animacion (Tiene que tener el mismo nombre que en el animator)
                animator.SetInteger("State", 0);

                //Abrir posibles mecanicas

                break;

            case State.Zarpazo:
                //Aplica la animacion (Tiene que tener el mismo nombre que en el animator)
                animator.SetInteger("State", 1);

                //Abrir posibles mecanicas

                break;

            case State.Mordisco:
                //Aplica la animacion (Tiene que tener el mismo nombre que en el animator)
                animator.SetInteger("State", 2);

                //Abrir posibles mecanicas

                break;
            case State.Fuego:
                //Aplica la animacion (Tiene que tener el mismo nombre que en el animator)
                animator.SetInteger("State", 3);

                //Abrir posibles mecanicas

                break;
        }


        if (impactoAtaque == true)
        {
            animator.SetBool("Impacto", true);

        }
        else if (impactoAtaque == false)
        {
            animator.SetBool("Impacto", false);

        }


    }
    public void GoIdle()
    {
        ataque = 0;
        impactoAtaque = false;

        StartCoroutine(EnableTriggers(tiempoEntreAtaques));

    }

    IEnumerator EnableTriggers(float tiempoEntreAtaques)
    {
        yield return new WaitForSeconds(tiempoEntreAtaques);

        deteccionFuego.SetActive(true);
        deteccionMordisco.SetActive(true);
        deteccionZarpa.SetActive(true);

    }

    public void ImpactarMordisco()
    {
        impactoAtaque = true;
    }

    public void ActivarImpactoZarpa()
    {
        impactoZarpa.SetActive(true);
    }

    public void DesactivarImpactoZarpa()
    {
        impactoZarpa.SetActive(false);
    }

    public void ActivarImpactoMordisco()
    {
        impactoMordisco.SetActive(true);
    }

    public void DesactivarImpactoMordisco()
    {
        impactoMordisco.SetActive(false);
    }

    public void ActivarImpactoFuego()
    {
        impactoFuego.SetActive(true);
    }

    public void DesactivarImpactoFuego()
    {
        impactoFuego.SetActive(false);
    }



}


