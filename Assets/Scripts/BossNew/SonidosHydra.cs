
using UnityEngine;

public class SonidosHydra : MonoBehaviour
{
    public AudioSource altavozSonidoLargo;
    public AudioSource altavozSonidoCorto;
    public AudioSource altavozSonidoExplosion;



    [Header("Sonidos:")]
    public AudioClip sonidoGolpeCabeza;
    public AudioClip sonidoRecibirGolpe;

    public AudioClip sonidoChispas;
    public AudioClip sonidoMordisco;

    public AudioClip sonidoZarpazo;

    public AudioClip sonidoFuego;

    public AudioClip sonidoTuercas;

    public AudioClip sonidoMuerte;
    public AudioClip sonidoExplosion;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SonidoGolpeCabeza()
    {
        altavozSonidoCorto.clip = sonidoGolpeCabeza;

        altavozSonidoCorto.Play();
    }

    public void SonidoMordisco()
    {
        altavozSonidoCorto.clip = sonidoMordisco;

        altavozSonidoCorto.Play();
    }

    public void SonidoRecibirGolpe()
    {
        altavozSonidoCorto.clip = sonidoRecibirGolpe;
        altavozSonidoCorto.Play();
    }

    public void SonidoTuercas()
    {
        altavozSonidoCorto.clip = sonidoTuercas;

        altavozSonidoCorto.Play();
    }

    public void SonidoChispas()
    {
        altavozSonidoLargo.clip = sonidoChispas;
        altavozSonidoLargo.loop = true;
        altavozSonidoLargo.Play();
    }

    public void SonidoZarpazo()
    {
        altavozSonidoLargo.clip = sonidoZarpazo;

        altavozSonidoLargo.Play();
    }


    public void SonidoFuego()
    {
        altavozSonidoLargo.clip = sonidoFuego;

        altavozSonidoLargo.Play();
    }

    public void StopAudioLargo()
    {
        altavozSonidoLargo.loop = false;
        altavozSonidoLargo.Stop();
    }
    public void SonidoMuerte()
    {
        altavozSonidoLargo.clip = sonidoMuerte;

        altavozSonidoLargo.Play();
    }
    public void SonidoExplosion()
    {
        altavozSonidoExplosion.clip = sonidoExplosion;

        altavozSonidoExplosion.Play();
    }
}
