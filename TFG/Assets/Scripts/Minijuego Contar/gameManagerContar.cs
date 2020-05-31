using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManagerContar : MonoBehaviour
{
    private static gameManagerContar instance;
    public static gameManagerContar Instance
    {
        get
        {
            return instance;
        }

    }
    private int contadorJaulasAcertadas;

    [Header("Panel Atributes")]
    public GameObject gameOverPanel;
    public GameObject tutorialPanel;
    public GameObject[] jaulas;
    public Image barra;
    public float porcentaje;
    public float totalPorcentaje;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        tutorialPanel.SetActive(true);
        contadorJaulasAcertadas = 0;
    }

    public void checkGameOver()
    {
        contadorJaulasAcertadas++;
        subirBarra();

        if(contadorJaulasAcertadas >= 3)
        {
            resetJaulas();
            contadorJaulasAcertadas = 0;
        }

        if(porcentaje >= totalPorcentaje)
        {
            displayGameOver();
        }
    }

    private void displayGameOver()
    {
        int aux = PlayerPrefs.GetInt("maxContar", 0);
        aux++;
        PlayerPrefs.SetInt("maxContar", aux);

        gameOverPanel.SetActive(true);
    }

    private void resetJaulas()
    {
        for (int i = 0; i < jaulas.Length; i++)
        {
            jaulas[i].GetComponent<jaulaScript>().resetLevel();
        }
    }

    public void goPlay()
    {
        ButtonSoundManager.Instance.playButtonSound();
        tutorialPanel.SetActive(false);
    }

    private void subirBarra()
    {
        porcentaje += 10;
        barra.fillAmount = porcentaje / totalPorcentaje;
    }
}
