using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerColorear : MonoBehaviour
{
    private static gameManagerColorear instance;
    public static gameManagerColorear Instance
    {
        get
        {
            return instance;
        }
    }

    [Header("UI properties")]
    public GameObject tutorialPanel;
    public GameObject finalPanel;

    [Header("Dibujos")]
    public GameObject dibujoVaquera;
    public GameObject operacionesVaquera;
    [Space]
    public GameObject dibujoNiña;
    public GameObject operacionesNiña;
    [Space]
    [Header("Colores Atributes")]
    public GameObject[] colores;

    private GameObject[] partesAColorear;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        partesAColorear = GameObject.FindGameObjectsWithTag("parteColorear");
        finalPanel.SetActive(false);
        tutorialPanel.SetActive(true);
    }

    public void goPlay()
    {
        ButtonSoundManager.Instance.playButtonSound();
        tutorialPanel.SetActive(false);
    }

    public void checkWin()
    {
        for (int i = 0; i < partesAColorear.Length; i++)
        {
            if (!partesAColorear[i].GetComponent<parteAColorear>().coloreada)
            {
                return;
            }
        }

        displayWin();
    }

    public void displayWin()
    {
        int aux = PlayerPrefs.GetInt("maxColorear", 0);
        aux++;
        PlayerPrefs.SetInt("maxColorear", aux);

        finalPanel.SetActive(true);
    }

    public void esconderPiezas()
    {
        for (int i = 0; i < partesAColorear.Length; i++)
        {
            partesAColorear[i].GetComponent<parteAColorear>().resetParte();
        }
    }

    public void buscarPiezas()
    {
        partesAColorear = GameObject.FindGameObjectsWithTag("parteColorear");
    }

    public void quitarDibujos()
    {
        dibujoVaquera.SetActive(false);
        operacionesVaquera.SetActive(false);
        dibujoNiña.SetActive(false);
        operacionesNiña.SetActive(false);
    }

    public void quitarPiezaAsociadaColor()
    {
        for (int i = 0; i < colores.Length; i++)
        {
            colores[i].GetComponent<dragColor>().resetParteColorear();
        }
    }

    public void mostrarDibujoVaquera()
    {
        esconderPiezas();
        quitarDibujos();
        quitarPiezaAsociadaColor();
        dibujoVaquera.SetActive(true);
        operacionesVaquera.SetActive(true);
        buscarPiezas();
    }

    public void mostrarDibujoNiña()
    {
        esconderPiezas();
        quitarDibujos();
        quitarPiezaAsociadaColor();
        dibujoNiña.SetActive(true);
        operacionesNiña.SetActive(true);
        buscarPiezas();
    }


}
