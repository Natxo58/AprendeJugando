using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerObjetos : MonoBehaviour
{
    private static gameManagerObjetos instance;
    public static gameManagerObjetos Instance
    {
        get
        {
            return instance;
        }
    }

    [Header("Level 0 Atributes")]
    public List<GameObject> objetosCorrectosLvl0 = new List<GameObject>();
    public Sprite level0Background;

    [Space]

    [Header("Level 1 Atributes")]
    public List<GameObject> objetosCorrectosLvl1 = new List<GameObject>();
    public Sprite level1Background;

    [Space]

    [Header("Level 2 Atributes")]
    public List<GameObject> objetosCorrectosLvl2 = new List<GameObject>();
    public Sprite level2Background;

    [Space]

    [Header("Level 3 Atributes")]
    public List<GameObject> objetosCorrectosLvl3 = new List<GameObject>();
    public Sprite level3Background;

    [Space]

    [Header("Level 4 Atributes")]
    public List<GameObject> objetosCorrectosLvl4 = new List<GameObject>();
    public Sprite level4Background;

    [Space]

    [Header("Niveles Atributes")]
    public GameObject[] niveles;
    public int indexNiveles;

    [Space]

    [Header("Objetos Atributes")]
    public List<GameObject> objetosSeleccionados;
    public List<GameObject> objetosCorrectos;

    [Space]

    [Header("UI Atributes")]
    public GameObject tutorialPanel;
    public GameObject finalPanel;
    public bool inTutorial;
    public bool finished;
    public bool comprobando;
    public GameObject background;
    public GameObject textNivel;
    public GameObject textError;

    // Start is called before the first frame update
    void Start()
    {
        tutorialPanel.SetActive(true);
        instance = this;
        calcularObjetosCorrectos();
        desactivarNiveles();
    }

    void calcularObjetosCorrectos()
    {
        objetosCorrectos.Clear();
        objetosSeleccionados.Clear();

        switch (indexNiveles)
        {
            case 0:
                objetosCorrectos = objetosCorrectosLvl0;
                background.GetComponent<SpriteRenderer>().sprite = level0Background;
                break;
            case 1:
                objetosCorrectos = objetosCorrectosLvl1;
                background.GetComponent<SpriteRenderer>().sprite = level1Background;
                break;
            case 2:
                objetosCorrectos = objetosCorrectosLvl2;
                background.GetComponent<SpriteRenderer>().sprite = level2Background;
                break;
            case 3:
                objetosCorrectos = objetosCorrectosLvl3;
                background.GetComponent<SpriteRenderer>().sprite = level3Background;
                break;
            case 4:
                objetosCorrectos = objetosCorrectosLvl4;
                background.GetComponent<SpriteRenderer>().sprite = level4Background;
                break;
        }
    }

    public void comprobarCorrectos()
    {
        if (objetosCorrectos.Count != objetosSeleccionados.Count)
        {
            objetosIncorrectos();
            return;
        }

        for (int i = 0; i < objetosSeleccionados.Count; i++)
        {
            if (!objetosCorrectos.Contains(objetosSeleccionados[i]))
            {
                objetosIncorrectos();
                return;
            }
        }

        callNextLevel();
    }

    private void callNextLevel()
    {
        int aux = PlayerPrefs.GetInt("maxObjetos", 0);
        aux++;
        PlayerPrefs.SetInt("maxObjetos", aux);

        audioManagerObjetos.Instance.playSoundAcierto();

        comprobando = true;
        textNivel.SetActive(true);
        Invoke("displayNextLevel", 1f);
    }

    private void noConseguido()
    {
        audioManagerObjetos.Instance.playSoundFallo();

        comprobando = true;
        textError.SetActive(true);
        Invoke("desactivarText", 1f);
    }

    private void desactivarText()
    {
        textError.SetActive(false);
        comprobando = false;
    }

    public void seleccionarObjeto(GameObject objeto)
    {
        objetosSeleccionados.Add(objeto);
    }

    public void deseleccionarObjeto(GameObject objeto)
    {
        if (objetosSeleccionados.Contains(objeto))
            objetosSeleccionados.Remove(objeto);
    }

    void objetosIncorrectos()
    {
        noConseguido();
    }

    void displayNextLevel()
    {
        textNivel.SetActive(false);
        comprobando = false;

        if (indexNiveles == niveles.Length - 1)
        {
            displayGameOver();
            return;
        }

        niveles[indexNiveles].SetActive(false);
        indexNiveles++;
        niveles[indexNiveles].SetActive(true);
        calcularObjetosCorrectos();
    }

    void desactivarNiveles()
    {
        for (int i = 1; i < niveles.Length; i++)
        {
            niveles[i].SetActive(false);
        }
    }

    public void goPlay()
    {
        inTutorial = false;
        ButtonSoundManager.Instance.playButtonSound();
        tutorialPanel.SetActive(false);
    }

    void displayGameOver()
    {
        finalPanel.SetActive(true);
    }
}
