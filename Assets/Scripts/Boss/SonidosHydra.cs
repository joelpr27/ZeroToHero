
using UnityEngine;

public class SonidosHydra : MonoBehaviour
{
    public AudioSource altavozSonidoLargo;
    public AudioSource altavozSonidoCorto;


    [Header("Sonidos:")]
    public AudioClip sonidoGolpeCabeza;
    public AudioClip sonidoChispas;

    public AudioClip sonidoZarpazo;


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

    public void StopAudioLargo()
    {
        altavozSonidoLargo.loop = false;
        altavozSonidoLargo.Stop();
    }
}
