
using UnityEngine;
using TMPro;

public class CalculoRangos : MonoBehaviour
{
    private GameManager gm;

    public GameObject guardado;
    [Space]
    public TMP_Text rangoLevel1;
    public TMP_Text rangoLevel2;
    public TMP_Text rangoLevel3;
    public TMP_Text rangoLevelBoss;

    private float LimitsD = 50000;
    private float LimitsC = 100000;
    private float LimitsB = 150000;
    private float LimitsA = 250000;
    private float LimitsS = 350000;
    private float LimitsSS = 400000f;

    void Rangos()
    {
        #region Level1
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel1 <= LimitsD)
            {
                rangoLevel1.text = "E";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel1 >= LimitsD)
            {
                rangoLevel1.text = "D";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel1 >= LimitsC)
            {
                rangoLevel1.text = "C";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel1 >= LimitsB)
            {
                rangoLevel1.text = "B";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel1 >= LimitsA)
            {
                rangoLevel1.text = "A";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel1 >= LimitsS)
            {
                rangoLevel1.text = "S";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel1 >= LimitsSS)
            {
                rangoLevel1.text = "S+";
            }
        #endregion

        #region Level2
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel2 <= LimitsD)
            {
                rangoLevel2.text = "E";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel2 >= LimitsD)
            {
                rangoLevel2.text = "D";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel2 >= LimitsC)
            {
                rangoLevel2.text = "C";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel2 >= LimitsB)
            {
                rangoLevel2.text = "B";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel2 >= LimitsA)
            {
                rangoLevel2.text = "A";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel2 >= LimitsS)
            {
                rangoLevel2.text = "S";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel2 >= LimitsSS)
            {
                rangoLevel2.text = "S+";
            }
        #endregion

        #region Level3
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel3 <= LimitsD)
            {
                rangoLevel3.text = "E";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel3 >= LimitsD)
            {
                rangoLevel3.text = "D";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel3 >= LimitsC)
            {
                rangoLevel3.text = "C";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel3 >= LimitsB)
            {
                rangoLevel3.text = "B";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel3 >= LimitsA)
            {
                rangoLevel3.text = "A";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel3 >= LimitsS)
            {
                rangoLevel3.text = "S";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel3 >= LimitsSS)
            {
                rangoLevel3.text = "S+";
            }
        #endregion

        #region LevelBoss
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivelBoss <= LimitsD)
            {
                rangoLevelBoss.text = "E";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivelBoss >= LimitsD)
            {
                rangoLevelBoss.text = "D";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivelBoss >= LimitsC)
            {
                rangoLevelBoss.text = "C";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivelBoss >= LimitsB)
            {
                rangoLevelBoss.text = "B";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivelBoss >= LimitsA)
            {
                rangoLevelBoss.text = "A";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivelBoss >= LimitsS)
            {
                rangoLevelBoss.text = "S";
            }
            if(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivelBoss >= LimitsSS)
            {
                rangoLevelBoss.text = "S+";
            }
        #endregion
    }

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        Rangos();
    }
}
