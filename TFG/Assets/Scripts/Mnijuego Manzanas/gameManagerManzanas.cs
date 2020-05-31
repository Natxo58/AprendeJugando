using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManagerManzanas : MonoBehaviour
{
    [Header("Scores")]
    public int score;
    public Text scoreText;


    [Header("Time Atributes")]
    public float maxTiempo;
    public float actualTiempo;
    public Text puntuacion;
    


    [Header("UI atributes")]
    public Image barraTiempo;
    public GameObject panelGameOver;
    public GameObject tutorialPanel;


    private static gameManagerManzanas instance;
    public static gameManagerManzanas Instance
    {
        get
        {
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        actualTiempo = maxTiempo;
        tutorialPanel.SetActive(true);
        instance = this;
    }

    private void Update()
    {
        if(actualTiempo <= 0)
        {
            displayGameOver();
        }
        else
        {
            actualTiempo -= Time.deltaTime;
            barraTiempo.fillAmount = actualTiempo / maxTiempo;
        }
    }

    public void aumentarScore()
    {
        score++;
        actualizarScore();
    }

    public void aumentarScoreDorada()
    {
        score+=5;
        actualizarScore();
    }

    private void actualizarScore()
    {
        scoreText.text = score.ToString();
    }

    private void displayGameOver()
    {
        if (score > PlayerPrefs.GetInt("maxManzanas", 0))
        {
            PlayerPrefs.SetInt("maxManzanas", score);
        }
        Time.timeScale = 0f;
        panelGameOver.SetActive(true);
        puntuacion.text = score.ToString();
    }

    public void goPlay()
    {
        ButtonSoundManager.Instance.playButtonSound();
        tutorialPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
