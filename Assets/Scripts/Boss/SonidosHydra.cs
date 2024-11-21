using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosHydra : MonoBehaviour
{
    public AudioSource altavoz;
    public AudioSource altavozGolpe;


    [Header("Sonidos:")]
    public AudioClip sonidoCuello;
    public AudioClip sonidoChispas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SonidoCuello()
    {
        altavoz.clip = sonidoCuello;

        altavoz.Play();
    }

    public void SonidoChispas()
    {
        altavoz.clip = sonidoChispas;
        altavoz.loop = true;
        altavoz.Play();
    }

    public void StopAudio()
    {
        altavoz.loop = false;
        altavoz.Stop();
    }
}
