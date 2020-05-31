using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gameManagerLaberinto : MonoBehaviour
{
    [System.Serializable]
    public class pathList
    {
        public GameObject[] camino;
    }

    private static gameManagerLaberinto instance;
    public static gameManagerLaberinto Instance
    {
        get
        {
            return instance;
        }
    }

    [Header("Lista caminos")]
    public pathList[] caminosLaberinto;
    public int sumaNumeros;
    public bool gameOver;

    [Header("UI panels")]
    public Text finalText;
    public Text sumaText;
    public Text numerosText;
    public GameObject tutorialPanel;
    public GameObject gameOverPanel;
    public bool tutorialDisplayed;

    private GameObject[] caminoElegido;
    private int indexCaminoElegido;
    private List<int> numerosDelCaminoElegido = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        tutorialDisplayed = true;
        tutorialPanel.SetActive(true);
        instance = this;
        selectRandomPath();
        for (int i = 0; i < numerosDelCaminoElegido.Count; i++)
        {
            Debug.Log(numerosDelCaminoElegido[i]);
        }

        takeRandomNumbersToSelectedPath();
        placeRandomNumbers();
        placePathNumbers();
    }

    void selectRandomPath()
    {
        int random = Random.Range(0, caminosLaberinto.Length);
        caminoElegido = caminosLaberinto[random].camino;
        indexCaminoElegido = random;

        for (int i = 0; i < caminoElegido.Length; i++)
        {
            Debug.Log(caminoElegido[i].name);
        }
    }

    void takeRandomNumbersToSelectedPath()
    {
        int suma = 0;
        numerosDelCaminoElegido.Clear();

        for (int i = 0; i < caminoElegido.Length; i++)
        {
            int random = Random.Range(0, 10);
            numerosDelCaminoElegido.Add(random);
            suma += random;
        }

        if (suma != sumaNumeros)
            takeRandomNumbersToSelectedPath();

    }

    void placeRandomNumbers()
    {
        for (int i = 0; i < caminosLaberinto.Length; i++)
        {
            for (int j = 0; j < caminosLaberinto[i].camino.Length; j++)
            {
                int random = Random.Range(0, 10);
                caminosLaberinto[i].camino[j].GetComponent<numeroScript>().cambiarNumero(random);
            }
        }
    }

    void placePathNumbers()
    {
        for (int i = 0; i < caminoElegido.Length; i++)
        {
            caminoElegido[i].GetComponent<numeroScript>().cambiarNumero(numerosDelCaminoElegido[i]);
        }
    }

    public void displayGameOver(List<int> list)
    {
        gameOver = true;
        int suma = 0;
        string numeros = "";

        gameOverPanel.SetActive(true);

        for (int i = 0; i < list.Count; i++)
        {
            suma += list[i];
            numeros = numeros + list[i].ToString();
            if(i != list.Count - 1)
            {
                numeros += ", ";
            }
        }

        if(suma == sumaNumeros)
        {
            audioManagerLaberinto.Instance.playSoundGanar();
            finalText.text = "Lo has conseguido";
            int aux = PlayerPrefs.GetInt("maxLaberinto", 0);
            aux++;
            PlayerPrefs.SetInt("maxLaberinto", aux);
        }
        else
        {
            audioManagerLaberinto.Instance.playSoundPerder();
            finalText.text = "Oh! Prueba de nuevo";
        }

        numerosText.text = numeros;
        sumaText.text = suma.ToString();
    }

    public void goPlay()
    {
        tutorialDisplayed = false;
        ButtonSoundManager.Instance.playButtonSound();
        tutorialPanel.SetActive(false);
    }
}
