using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerFiguras : MonoBehaviour
{
    private static gameManagerFiguras instance;
    public static gameManagerFiguras Instance
    {
        get
        {
            return instance;
        }
    }

    [Header("Figuras Atributes")]
    public GameObject[] figuras;
    public Transform[] spawnPoints;
    public Transform[] huecosSpawnPoints;
    public int cantidadFiguras;

    [Header("UI Atributes")]
    public GameObject tutorialPanel;
    public GameObject finalPanel;

    [Header("Game Atributes")]
    public bool inTutorial;

    private List<GameObject> figurasActivas = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        inTutorial = true;
        tutorialPanel.SetActive(true);
        instance = this;
        spawnFiguras();
    }

    private void spawnFiguras()
    {
        figurasActivas.Clear();

        for (int i = 0; i < cantidadFiguras; i++)
        {
            int random = Random.Range(0, cantidadFiguras);
            while (figuras[random].activeSelf)
            {
                random = Random.Range(0, figuras.Length);
            }

            figuras[random].transform.position = figuras[random].GetComponent<dragFiguraGeometrica>().posicionInicial = spawnPoints[i].position;
            figuras[random].SetActive(true);
            figurasActivas.Add(figuras[random]);
        }

        spawnHuecos();
    }

    private void spawnHuecos()
    {
        List<int> indexAsignados = new List<int>();

        for (int i = 0; i < figurasActivas.Count; i++)
        {
            figurasActivas[i].GetComponent<dragFiguraGeometrica>().huecoCorrespondiente.SetActive(true);
            int random = Random.Range(0, huecosSpawnPoints.Length);
            while (indexAsignados.Contains(random))
            {
                random = Random.Range(0, huecosSpawnPoints.Length);
            }
            indexAsignados.Add(random);
            figurasActivas[i].GetComponent<dragFiguraGeometrica>().huecoCorrespondiente.transform.position = huecosSpawnPoints[random].position;
        }
    }

    public void CheckGameOver()
    {
        for (int i = 0; i < figurasActivas.Count; i++)
        {
            if (!figurasActivas[i].GetComponent<dragFiguraGeometrica>().enHuecoCorrespondiente)
                return;
        }

        int aux = PlayerPrefs.GetInt("maxFiguras", 0);
        aux++;
        PlayerPrefs.SetInt("maxFiguras", aux);

        displayGameOver();
    }

    private void displayGameOver()
    {
        finalPanel.SetActive(true);
    }

    public void goPlay()
    {
        inTutorial = true;
        ButtonSoundManager.Instance.playButtonSound();
        tutorialPanel.SetActive(false);
    }
}
