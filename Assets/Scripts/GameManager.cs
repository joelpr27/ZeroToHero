using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

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

#region Partida
    public void Score()
    {
        currentPoints += Random.Range(100, 150);
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
        if(GamePanel)
        {
            GamePanel.SetActive(!GamePanel.activeSelf);
            Debug.Log(GamePanel.activeSelf);    
        }
    }

    public void PausePanelInteract()
    {

    }

    public void OptionsPanelInteract()
    {
        OptionsPanel.SetActive(!OptionsPanel.activeSelf);
        Debug.Log(OptionsPanel.activeSelf);
    }
#endregion
    
    void Start()
    {
        currentCountDelate = maxCountDelate;

        points = 0;
        currentPoints = points;

        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            MenuPanel.SetActive(true);
            GamePanel.SetActive(false);
            PausePanel.SetActive(false);
            OptionsPanel.SetActive(false);
            LevelsPanel.SetActive(false);
            ConsejosPanel.SetActive(false);
        }
        if(SceneManager.GetActiveScene().buildIndex >= 1)
        {
            MenuPanel.SetActive(false);
            GamePanel.SetActive(false);
            PausePanel.SetActive(false);
            OptionsPanel.SetActive(false);
            LevelsPanel.SetActive(false);
            ConsejosPanel.SetActive(false);
        }
    }

    void Update()
    {
        UpdateScoreText();

        UpdateTimeDelate();
    }
}
