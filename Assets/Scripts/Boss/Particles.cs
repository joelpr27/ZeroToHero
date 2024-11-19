using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    [Header("Chispas:")]

    //Game Object de las particulas de las Chispas
    public ParticleSystem p_Cabeza;
    public ParticleSystem p_C_Sup;
    public ParticleSystem p_C_Inf;


    [Header("Humo:")]

    //Game Object de las particulas del Humo
    public ParticleSystem p_P1_Humo;

    [Header("Fuego:")]

    //Game Object de las particulas del Fuego
    public ParticleSystem p_C1_Fuego;
    public ParticleSystem p_C2_Fuego;
    public ParticleSystem p_C3_Fuego;

    public void Start()
    {
        // Debug.Log("Desactivar Particulas");

        p_Cabeza.Stop();
        p_C_Sup.Stop();
        p_C_Inf.Stop();

        p_P1_Humo.Stop();

        p_C1_Fuego.Stop();
        p_C2_Fuego.Stop();
        p_C3_Fuego.Stop();

    }

    public void ActivarChispas()
    {
        // Debug.Log("Activa Particulas Chispas");

        p_Cabeza.Play();
        p_C_Sup.Play();
        p_C_Inf.Play();
    }

    public void DesactivarChispas()
    {
        // Debug.Log("Desactiva Particulas Chispas");

        p_Cabeza.Stop();
        p_C_Sup.Stop();
        p_C_Inf.Stop();


    }

    public void ActivarHumo()
    {
        // Debug.Log("Activa Particulas Humo");

        p_P1_Humo.Play();
    }

    public void ActivarFuego()
    {
        // Debug.Log("Activa Particulas Fuego");

        p_C1_Fuego.Play();
        p_C2_Fuego.Play();
        p_C3_Fuego.Play();

    }

    public void DesactivarFuego()
    {
        // Debug.Log("Desactiva Particulas Fuego");

        p_C1_Fuego.Stop();
        p_C2_Fuego.Stop();
        p_C3_Fuego.Stop();

    }

}

