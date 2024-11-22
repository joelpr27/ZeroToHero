using UnityEngine;
using TMPro;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    [Header("Partida")]
    /* public int points;
    public int currentPoints;
    public TMP_Text textScore; */

    private LevelInfo LI;
    public GameObject guardado;
    public DatosGuardado datosGuardado;
    public bool areYouWinningSon;
    [Space]

    [Header("particulas")]
    public float maxCountDelate = 2.0f;
    public float currentCountDelate;
    [Space]

    [Header("Menus")]
    public GameObject MenuPanel;
    public GameObject GamePanel;
    public GameObject VictoryPanel;
    public GameObject PausePanel;
    public GameObject OptionsPanel;
    public GameObject LevelsPanel;
    public GameObject ConsejosPanel;
    public GameObject CreditsPanel;
    [Space]

    [Header("Audio")]
    public AudioClip[] audios;
    [Space]
    private AudioSource controlAudio;
    [Space]
    public AudioSource hoverButton;
    public AudioSource pressButton;
    public AudioSource menuMusic;
    [Space]

    [Header("Settings")]
    public AudioMixer audioMixer;

    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;
    private float currentRefreshRate;
    private int currentResolutionIndex = 0;
    [Space]

    [Header("LevelInfo")]
    public TMP_Text puntosLevel1;
    public TMP_Text puntosLevel2;
    public TMP_Text puntosLevel3;
    public TMP_Text puntosLevelBoss;

#region Partida
    /* public void Score()
    {
        currentPoints += 100;
    }

    void UpdateScoreText()
    {
        textScore.text = "PUNTOS " + currentPoints.ToString();
    } */

    void UpdateTimeDelate()
    {
        currentCountDelate -= Time.deltaTime;

        GameObject enemyParticle = GameObject.Find("EnemyDeathParticle(Clone)");

        if (currentCountDelate <= 0 && enemyParticle != null)
        {
            int particleCount = GameObject.FindObjectsOfType<GameObject>().Count(obj => obj.name == "EnemyDeathParticle(Clone)");

            if (particleCount > 5)
            {
                Destroy(enemyParticle);
            }

            currentCountDelate = maxCountDelate;
        }
    }
    void DelataOtherGameManager()
    {
        GameObject gameManager = GameObject.Find("GameManager");

        if (gameManager != null)
        {
            int gameManagerCount = GameObject.FindObjectsOfType<GameObject>().Count(obj => obj.name == "GameManager");

            if (gameManagerCount > 1)
            {
                Destroy(gameManager);
            }
        }
    }

    public void UpdatePointsMenu()
    {
        Debug.Log(guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel1);
        puntosLevel1.text = guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel1.ToString("0");
        puntosLevel2.text = guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel2.ToString("0");
        puntosLevel3.text = guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivel3.ToString("0");
        puntosLevelBoss.text = guardado.GetComponent<GuardarPartida>().datosGuardado.puntosNivelBoss.ToString("0");
    }
#endregion

#region Scenes
    public void Menu()
    {
        SceneManager.LoadScene(0);

        areYouWinningSon = false;

        //menuMusic.Play();
    }

    public void JugarLevel1()
    {
        SceneManager.LoadScene(1);

        IrAJuego();
    }

    public void JugarLevel2()
    {
        SceneManager.LoadScene(2);

        IrAJuego();
    }

    public void JugarLevel3()
    {
        SceneManager.LoadScene(3);

        IrAJuego();
    }

    public void JugarLevelBoss()
    {
        SceneManager.LoadScene(4);

        IrAJuego();
    }

    //hacer mas si tenemos mas Escenas

    public void ExitGame()
    {
        Application.Quit();
    }
#endregion

#region Panels
    public void GamePanelInteract()
    {
        GamePanel.SetActive(!GamePanel.activeSelf);
        Debug.Log(GamePanel.activeSelf);
    }

    public void PausePanelInteract()
    {
        if(SceneManager.GetActiveScene().buildIndex >= 1 && Input.GetButtonDown("Cancel"))
        {
            PausePanel.SetActive(!PausePanel.activeSelf);
            Debug.Log(PausePanel.activeSelf);

            OptionsPanel.SetActive(false);
        }

        if(SceneManager.GetActiveScene().buildIndex >= 1)
        {
            if(PausePanel.activeSelf == true)
            {
                Time.timeScale = 0;
                
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1;

                Cursor.visible = false;
            }
        }
    }
    public void DesactivarPausa()
    {
        PausePanel.SetActive(false);
        Cursor.visible = false;
    }

    public void OptionsPanelInteract()
    {
        OptionsPanel.SetActive(!OptionsPanel.activeSelf);
        Debug.Log(OptionsPanel.activeSelf);

        Cursor.visible = true;
    }

    public void LevelsPanelInteract()
    {
        LevelsPanel.SetActive(!LevelsPanel.activeSelf);
        Debug.Log(LevelsPanel.activeSelf);

        Cursor.visible = true;
    }

    public void ConsejosPanelInteract()
    {
        ConsejosPanel.SetActive(!ConsejosPanel.activeSelf);
        Debug.Log(ConsejosPanel.activeSelf);

        Cursor.visible = true;
    }

    public void CreditsPanelInteract()
    {
        CreditsPanel.SetActive(!CreditsPanel.activeSelf);
        Debug.Log(CreditsPanel.activeSelf);

        Cursor.visible = true;
    }

    public void WinPanel()
    {
        if(areYouWinningSon == true)
        {
            VictoryPanel.SetActive(true);
            GamePanel.SetActive(false);

            Time.timeScale = 0;

            Cursor.visible = true;
        }
        else
        {
            VictoryPanel.SetActive(false);
        }
    }

    public void ButtonHover()
    {
        hoverButton.Play();
    }

    public void ButtonPress()
    {
        pressButton.Play();
    }

    public void IrAJuego()
    {
        areYouWinningSon = false;

        MenuPanel.SetActive(false);
        GamePanel.SetActive(true);
        VictoryPanel.SetActive(false);
        PausePanel.SetActive(false);
        OptionsPanel.SetActive(false);
        LevelsPanel.SetActive(false);
        ConsejosPanel.SetActive(false);
        CreditsPanel.SetActive(false);

        LI.EnterInGame();

        LI.points = 0;

        LI.bounsPoints = 0;

        LI.time = 0;

        LI.starTimer = false;

        menuMusic.Stop();
    }

#endregion
    
#region Settings
    //repasar el volumen, no va hacia el db negativo y se escuchara muy alto
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void FullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }
#endregion
    void Start()
    {
        #region Partida
            LI = GameObject.Find("LevelInfo").GetComponent<LevelInfo>();

            Time.timeScale = 1;

            currentCountDelate = maxCountDelate;

            /* points = 0;
            currentPoints = points; */

            if(SceneManager.GetActiveScene().buildIndex == 0)
            {
                Cursor.visible = true;
            }
            if(SceneManager.GetActiveScene().buildIndex >= 1)
            {
                Cursor.visible = false;
            }

            areYouWinningSon = false;
        #endregion
        
        #region Panels
            if(SceneManager.GetActiveScene().buildIndex == 0)
            {
                LI.EnterInGame();

                MenuPanel.SetActive(true);
                GamePanel.SetActive(false);
                VictoryPanel.SetActive(false);
                PausePanel.SetActive(false);
                OptionsPanel.SetActive(false);
                LevelsPanel.SetActive(false);
                ConsejosPanel.SetActive(false);
                CreditsPanel.SetActive(false);
            }
            if(SceneManager.GetActiveScene().buildIndex >= 1)
            {
                IrAJuego();
            }
        #endregion

        #region Audio
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            menuMusic.Play();
        }
        #endregion

        #region Settings
            resolutions = Screen.resolutions;
            filteredResolutions = new List<Resolution>();

            resolutionDropdown.ClearOptions();
            currentRefreshRate = (float)Screen.currentResolution.refreshRateRatio.value; // Convertir a float

            for (int i = 0; i < resolutions.Length; i++)
            {
                // Comparar el refresh rate ratio utilizando su valor convertido a float
                if ((float)resolutions[i].refreshRateRatio.value == currentRefreshRate)
                {
                    filteredResolutions.Add(resolutions[i]);
                }
            }

            List<string> options = new List<string>();
            for (int i = 0; i < filteredResolutions.Count; i++)
            {
                string resolutionOption = filteredResolutions[i].width + " x " + filteredResolutions[i].height;
                options.Add(resolutionOption);

                if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height)
                {
                    currentResolutionIndex = i;
                }
            }

            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();
        #endregion

        //DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        //UpdateScoreText();

        UpdateTimeDelate();

        PausePanelInteract();

        WinPanel();

        DelataOtherGameManager();
    }
}
