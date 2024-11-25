
using UnityEngine;

public class IniciarPelea : MonoBehaviour
{
    [Header("Arboles y Borde de Pelea Izq:")]
    public GameObject Arbol1;
    public GameObject Arbol2;

    public GameObject ZonaAzucar;
    public GameObject BordePelea;

    [Header("Boss:")]
    public GameObject hydra;



    Animator animatorArbol1;
    Animator animatorArbol2;


    // Start is called before the first frame update
    void Start()
    {
        animatorArbol1 = Arbol1.GetComponent<Animator>();
        animatorArbol2 = Arbol2.GetComponent<Animator>();

        animatorArbol1.SetBool("Suelo", false);
        animatorArbol2.SetBool("Suelo", false);

        ZonaAzucar.SetActive(true);
        BordePelea.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Inicia Pelea");

            animatorArbol1.SetBool("Suelo", true);
            animatorArbol2.SetBool("Suelo", true);

            ZonaAzucar.SetActive(false);
            BordePelea.SetActive(true);

            hydra.GetComponent<Pelea>().IniciarBatalla();

        }
    }



}
