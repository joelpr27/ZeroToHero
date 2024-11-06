using UnityEngine;
using TMPro;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    [Header("Partida")]
    public int points;
    public int currentPoints;
    public TMP_Text textScore;

    public float maxCountDelate = 2.0f;
    public float currentCountDelate;
    [Space]

    [Header("Menus")]
    public GameObject MenuPanel;
    public GameObject GamePanel;
    public GameObject PausePanel;
    public GameObject OptionsPanel;
    public GameObject LevelsPanel;
    public GameObject ConsejosPanel;
    public GameObject CreditsPanel;
    [Space]

    [Header("Settings")]
    public AudioMixer audioMixer;

    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;
    private float currentRefreshRate;
    private int currentResolutionIndex = 0;

#region Partida
    public void Score()
    {
        currentPoints += 100;
    }

    void UpdateScoreText()
    {
        textScore.text = "PUNTOS " + currentPoints.ToString();
    }

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
#endregion

#region Scenes
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void JugarLevel1()
    {
        SceneManager.LoadScene(1);
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
            Time.timeScale = 1;

            currentCountDelate = maxCountDelate;

            points = 0;
            currentPoints = points;

            if(SceneManager.GetActiveScene().buildIndex == 0)
            {
                Cursor.visible = true;
            }
            if(SceneManager.GetActiveScene().buildIndex >= 1)
            {
                Cursor.visible = false;
            }
        #endregion
        
        #region Panels
            if(SceneManager.GetActiveScene().buildIndex == 0)
            {
                MenuPanel.SetActive(true);
                GamePanel.SetActive(false);
                PausePanel.SetActive(false);
                OptionsPanel.SetActive(false);
                LevelsPanel.SetActive(false);
                ConsejosPanel.SetActive(false);
                CreditsPanel.SetActive(false);
            }
            if(SceneManager.GetActiveScene().buildIndex >= 1)
            {
                MenuPanel.SetActive(false);
                GamePanel.SetActive(false);
                PausePanel.SetActive(false);
                OptionsPanel.SetActive(false);
                LevelsPanel.SetActive(false);
                ConsejosPanel.SetActive(false);
                CreditsPanel.SetActive(false);
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
                string resolutionOption = filteredResolutions[i].width + " x " + filteredResolutions[i].height + " " + (float)filteredResolutions[i].refreshRateRatio.value + " Hz";
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
    }

    void Update()
    {
        UpdateScoreText();

        UpdateTimeDelate();

        PausePanelInteract();
    }
}
