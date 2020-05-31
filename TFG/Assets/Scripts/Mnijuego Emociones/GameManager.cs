using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;

    [Header("UI")]
    public Text scoreText;
    public Text puntuacionFinal;
    public Text porcentajeTotal;
    public GameObject finalPanel;
    public GameObject tutorialPanel;

    [Header("Atributos Partida")]
    private float maxRounds;
    public float maxTime;
    public float aciertos;

    private int actualRounds;

    private static GameManager instance;
    public static GameManager Instance
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
        finalPanel.SetActive(false);
        tutorialPanel.SetActive(true);
        instance = this;
        score = 0;
    }


    #region getters & setters

    public int getScore()
    {
        return score;
    }


    #endregion


    #region functions

    public void aumentarScore(int amount)
    {
        score += amount;
        aciertos++;
        maxRounds++;
        actualizarImagen();
        audioManagerEmociones.Instance.playSonidoAcierto();
    }

    public void disminuirScore(int amount)
    {
        maxRounds++;
        score -= amount;
        if (score < 0)
            score = 0;
        actualizarImagen();
        audioManagerEmociones.Instance.playSonidoFallo();
    }

    void actualizarImagen()
    {
        scoreText.text = score.ToString();
    }

    public void checkFinal()
    {
        if (actualRounds >= maxRounds)
            finish();
    }

    public void addRound()
    {
        actualRounds++;
    }

    public void finish()
    {
        if(score > PlayerPrefs.GetInt("maxEmociones", 0))
        {
            PlayerPrefs.SetInt("maxEmociones", score);
        }

        finalPanel.SetActive(true);
        updateFinalPanel();
        Time.timeScale = 0f;
    }

    void updateFinalPanel()
    {
        puntuacionFinal.text = score.ToString();
        if (aciertos != 0)
        {
            float porcentaje = (aciertos / maxRounds) * 100;
            var resultado = (Mathf.Round(porcentaje * 100)) / 100.0;
            Debug.Log(porcentaje);
            string porcentajeString = resultado.ToString() + " %";
            porcentajeTotal.text = porcentajeString;
        }
        else
        {
            porcentajeTotal.text = "0 %";
        }
    }

    public void goPlay()
    {
        ButtonSoundManager.Instance.playButtonSound();

        tutorialPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    #endregion

}
