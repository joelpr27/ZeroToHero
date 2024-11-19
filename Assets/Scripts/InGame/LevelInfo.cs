using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LevelInfo : MonoBehaviour
{
    private GameManager gm;
    
    [Header("Puntos")]
    public int points;
    public int bounsPoints;
    public float totalPoints;

    public TMP_Text textScore;
    [Space]

    [Header("Tiempo")]
    public float time;

    public bool starTimer = false;

    public TMP_Text textTime;
    [Space]

    public GameObject bonus1;
    public GameObject bonus2;
    public GameObject bonus3;
    public GameObject bonus1Negro;
    public GameObject bonus2Negro;
    public GameObject bonus3Negro;
    public TMP_Text totalScore;

    public void Score()
    {
        points += 100;
    }

    public void BonusPointsLI()
    {
        points += 1000;
    }

    void UpdateScoreText()
    {
        textScore.text = "PUNTOS " + points.ToString();
    }

    void StartTimer()
    {
        if(starTimer == true)
        {
            time += Time.deltaTime;

            textTime.text = time.ToString("00.00");
        }
    }

    void PointsTotal()
    {
        totalPoints = (((100 + (bounsPoints * 10)) - (time / 10)) * points);
        totalScore.text = "Puntos totales: " + totalPoints.ToString("0");

        if(totalPoints <= 0)
        {
            totalPoints = 0;
        }
    }

    void ViewBonusPointsLI()
    {
        if(bounsPoints <= 0)
        {
            bonus1.SetActive(false);
            bonus2.SetActive(false);
            bonus3.SetActive(false);
            bonus1Negro.SetActive(true);
            bonus2Negro.SetActive(true);
            bonus3Negro.SetActive(true);
        }
        if(bounsPoints == 1)
        {
            bonus1.SetActive(true);
            bonus2.SetActive(false);
            bonus3.SetActive(false);
            bonus1Negro.SetActive(false);
            bonus2Negro.SetActive(true);
            bonus3Negro.SetActive(true);
        }
        if(bounsPoints == 2)
        {
            bonus1.SetActive(true);
            bonus2.SetActive(true);
            bonus3.SetActive(false);
            bonus1Negro.SetActive(false);
            bonus2Negro.SetActive(false);
            bonus3Negro.SetActive(true);
        }
        if(bounsPoints >= 3)
        {
            bonus1.SetActive(true);
            bonus2.SetActive(true);
            bonus3.SetActive(true);
            bonus1Negro.SetActive(false);
            bonus2Negro.SetActive(false);
            bonus3Negro.SetActive(false);
        }
    }

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        points = 0;

        bounsPoints = 0;

        time = 0;
        starTimer = false;
    }

    void Update()
    {
        PointsTotal();

        StartTimer();

        UpdateScoreText();

        ViewBonusPointsLI();
    }
}
