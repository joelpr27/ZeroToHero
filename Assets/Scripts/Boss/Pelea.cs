using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelea : MonoBehaviour
{
    enum State { Idle, Mordisco, Zarpazo, Fuego };

    public Animator animator;

    [Header("Combate:")]

    public int ataque;
    public bool ataqueZarpa;
    public bool ataqueMordisco;
    public bool ataqueFuego;
    public bool impactoAtaque;

    public int tiempoPrimerAtaque = 20;
    public int tiempoEntreAtaques = 10;


    [Header("Trigger Deteccion:")]

    public GameObject triggerZarpa;
    public GameObject triggerMordisco;
    public GameObject triggerFuego;

    [Header("Trigger Impacto:")]

    public GameObject impactorZarpa;
    public GameObject impactorMordisco;
    public GameObject impactorFuego;



    State state;

    // Start is called before the first frame update
    void Start()
    {
        DesactivarTriggers("all");
        StartCoroutine(ActivarTriggers(tiempoPrimerAtaque));

        animator = GetComponent<Animator>();
        state = State.Idle;
        ataque = 0;

        ataqueZarpa = false;
        ataqueMordisco = false;
        ataqueFuego = false;


    }

    // Update is called once per frame
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

        if (ataqueZarpa == true && ataqueMordisco == false && ataqueFuego == false)
        {
            ataque = 1;
        }
        else if (ataqueZarpa == false && ataqueMordisco == true && ataqueFuego == false)
        {
            ataque = 2;
        }
        else if (ataqueZarpa == false && ataqueMordisco == false && ataqueFuego == true)
        {
            ataque = 3;
        }
        else
        {
            ataque = 0;
            impactoAtaque = false;
            animator.SetBool("Impacto", false);

        }

    }

    IEnumerator GoIdle(float tiempo)
    {
        Debug.Log("Deactivar Triggers");
        StartCoroutine(ActivarTriggers(tiempoEntreAtaques));

        yield return new WaitForSeconds(tiempo);

        ataqueZarpa = false;
        ataqueMordisco = false;
        ataqueFuego = false;

        ataque = 0;
        impactoAtaque = false;
        animator.SetBool("Impacto", false);
    }

    public void Golpear(string zona)
    {
        Debug.Log("El jugador esta en " + zona);

        if (zona == "TriggerZarpazo")
        {
            ataqueZarpa = true;
            ataqueMordisco = false;
            ataqueFuego = false;

            Debug.Log("Empieza Zarpa");

        }
        else if (zona == "TriggerMordisco")
        {
            ataqueZarpa = false;
            ataqueMordisco = true;
            ataqueFuego = false;

            Debug.Log("Empieza Mordisco");

        }
        else if (zona == "TriggerFuego")
        {
            ataqueZarpa = false;
            ataqueMordisco = false;
            ataqueFuego = true;

            Debug.Log("Empieza Fuego");

        }

    }

    public void ImpactarMordisco()
    {
        impactoAtaque = true;
        animator.SetBool("Impacto", true);

        StartCoroutine(GoIdle(1.3f));
    }

    public void Esquive(float tiempo)
    {
        // Debug.Log("ESQUIVE");

        StartCoroutine(GoIdle(tiempo));
    }

    public void DesactivarTriggers(string triggerDeactivados)
    {
        if (triggerDeactivados == "all")
        {
            //Deactiva todos los triggers
            triggerZarpa.SetActive(false);
            triggerMordisco.SetActive(false);
            triggerFuego.SetActive(false);
        }
        else if (triggerDeactivados == "MF")
        {
            //Deja activo el trigger de Zarpa
            triggerMordisco.SetActive(false);
            triggerFuego.SetActive(false);
        }
        else if (triggerDeactivados == "ZF")
        {
            //Deja activo el trigger de Mordisco
            triggerZarpa.SetActive(false);
            triggerFuego.SetActive(false);
        }
        else if (triggerDeactivados == "ZM")
        {
            //Deja activo el trigger de Fuego
            triggerZarpa.SetActive(false);
            triggerMordisco.SetActive(false);
        }

    }

    IEnumerator ActivarTriggers(int tiempo)
    {
        yield return new WaitForSeconds(tiempo);

        triggerZarpa.SetActive(true);
        triggerMordisco.SetActive(true);
        triggerFuego.SetActive(true);
    }

    public void ActivarImpactoZarpa()
    {
        impactorZarpa.SetActive(true);
    }

    public void DesactivarImpactoZarpa()
    {
        impactorZarpa.SetActive(false);
    }

    public void ActivarImpactoMordisco()
    {
        impactorMordisco.SetActive(true);
    }

    public void DesactivarImpactoMordisco()
    {
        impactorMordisco.SetActive(false);
    }

    public void ActivarImpactoFuego()
    {
        impactorFuego.SetActive(true);
    }

    public void DesactivarImpactoFuego()
    {
        impactorFuego.SetActive(false);
    }

}