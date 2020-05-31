using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerEmpatia : MonoBehaviour
{
    private static gameManagerEmpatia instance;
    public static gameManagerEmpatia Instance
    {
        get
        {
            return instance;
        }
    }

    [Header("UI Atributes")]
    public GameObject tutorialPanel;
    public GameObject finalPanel;
    public GameObject textoPasarNivel;
    public GameObject textoErrorNivel;

    [Header("Secuencias Atributes")]
    public GameObject[] opciones;
    public GameObject secuenciaActiva;
    public GameObject[] secuencias;
    public List<GameObject> secuenciasRestantes = new List<GameObject>();

    [Header("Bools")]
    public bool comprobando;
    public bool inTutorial;
    public bool finished;


    // Start is called before the first frame update
    void Start()
    {
        tutorialPanel.SetActive(true);
        inTutorial = true;
        instance = this;
        llenarListaSecuencias();
        elegirSecuenciaAleatoria();
    }

    void llenarListaSecuencias()
    {
        secuenciasRestantes.Clear();
        for (int i = 0; i < secuencias.Length; i++)
        {
            secuenciasRestantes.Add(secuencias[i]);
        }
    }

    void elegirSecuenciaAleatoria()
    {
        if (secuenciasRestantes.Count == 0)
        {
            displayGameOver();
            return;
        }

        int random = Random.Range(0, secuenciasRestantes.Count);

        if (secuenciaActiva != null)
        {
            secuenciaActiva.SetActive(false);
            secuenciaActiva.GetComponent<secuenciaEmpatiaScript>().desactivarTexto();
        }
        secuenciaActiva = secuenciasRestantes[random];
        secuenciaActiva.SetActive(true);
        secuenciaActiva.GetComponent<secuenciaEmpatiaScript>().activarTexto();
        secuenciasRestantes.RemoveAt(random);
    }

    void resetNuevaSecuencia()
    {
        textoPasarNivel.SetActive(false);
        textoErrorNivel.SetActive(false);
        comprobando = false;

        for (int i = 0; i < opciones.Length; i++)
        {
            opciones[i].GetComponent<empatiaScript>().resetEmpatia();
        }
        elegirSecuenciaAleatoria();
    }

    void displayGameOver()
    {
        int aux = PlayerPrefs.GetInt("maxEmpatia", 0);
        aux++;
        PlayerPrefs.SetInt("maxEmpatia", aux);

        finished = true;
        finalPanel.SetActive(true);
    }

    void mostrarTextoPasarNivel()
    {
        audioManagerEmpatia.Instance.playSoundAcierto();
        comprobando = true;
        textoPasarNivel.SetActive(true);
        Invoke("resetNuevaSecuencia", 1f);
    }

    void mostrarTextoErrorNivel()
    {
        audioManagerEmpatia.Instance.playSoundFallo();
        comprobando = true;
        textoErrorNivel.SetActive(true);
        Invoke("desactivarTextoError", 1f);
    }

    void desactivarTextoError()
    {
        comprobando = false;
        textoErrorNivel.SetActive(false);

        for (int i = 0; i < opciones.Length; i++)
        {
            opciones[i].GetComponent<empatiaScript>().resetEmpatia();
        }
    }

    public void goPlay() { 
        inTutorial = false;
        //ButtonSoundManager.Instance.playButtonSound();
        tutorialPanel.SetActive(false);
    }

    public void comprobarEmocion(string s)
    {
        if(s == secuenciaActiva.GetComponent<secuenciaEmpatiaScript>().emocionExpresada)
        {
            mostrarTextoPasarNivel();
        }
        else
        {
            mostrarTextoErrorNivel();
        }
    }

    

}
