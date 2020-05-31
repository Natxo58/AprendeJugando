using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerOrdenar : MonoBehaviour
{
    private static gameManagerOrdenar instance;
    public static gameManagerOrdenar Instance
    {
        get
        {
            return instance;
        }
    }

    [Header("UI Atributes")]
    public GameObject[] huecos;
    public GameObject[] huecos3;
    public GameObject[] huecos4;
    public GameObject hueco3;
    public GameObject hueco4;
    public GameObject[] secuencias;
    public GameObject tutorialPanel;
    public GameObject finalPanel;
    

    [Space]
    [Header("Game Manager Atributes")]
    public bool finished;
    public bool inTutorial;

    private int indexSecuencias = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        inTutorial = true;
        tutorialPanel.SetActive(true);
        huecos = huecos3;
        hueco4.SetActive(false);
        hueco3.SetActive(true);
        instance = this;
        cargarSecuencia(indexSecuencias);
    }

    public void comprobarFotos()
    {
        comprobarFotosHuecos();

        for (int i = 0; i < huecos.Length; i++)
        {
            if (!huecos[i].GetComponent<huecoScript>().fotoCorrecta())
            {
                devolverFotos();
                return;
            }
        }

        cargarSecuencia(indexSecuencias);
    }

    public void devolverFotos()
    {
        for (int i = 0; i < huecos.Length; i++)
        {
            huecos[i].GetComponent<huecoScript>().devolverFotosErroneasPosicionInicial();
        }
    }

    public void goPlay()
    {
        inTutorial = false;
        ButtonSoundManager.Instance.playButtonSound();
        tutorialPanel.SetActive(false);
    }

    public void cargarSecuencia(int n)
    {
        int aux = PlayerPrefs.GetInt("maxOrdenar", 0);
        aux++;
        PlayerPrefs.SetInt("maxOrdenar", aux);

        if(indexSecuencias >= secuencias.Length){
            displayGameOver();
            return;
        }

        if (n > 0)
        {
            secuencias[n - 1].SetActive(false);
            audiomanagerOrdenar.Instance.playAciertoSound();
        }

        if (n == 3) cambiarHuecos();

        secuencias[n].SetActive(true);
        indexSecuencias++;
    }

    private void cambiarHuecos()
    {
        hueco3.SetActive(false);
        hueco4.SetActive(true);
        huecos = huecos4;
    }

    public void displayGameOver()
    {
        audiomanagerOrdenar.Instance.playAciertoSound();
        finished = true;
        finalPanel.SetActive(true);
    }

    public void comprobarFotosHuecos()
    {
        for (int i = 0; i < huecos.Length; i++)
        {
            huecos[i].GetComponent<huecoScript>().comprobarFotoPuesta();
        }
    }
}
