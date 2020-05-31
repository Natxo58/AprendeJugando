using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerPuzzle : MonoBehaviour
{
    [Header("Puzzle Atributes")]
    public float distanciaUnionGrid;
    public List<GameObject> piezas = new List<GameObject>();
    public List<int> IDsAsignados = new List<int>();
    public List<gridPointScript> gridPointScripts = new List<gridPointScript>();
    [Space]
    public Sprite[] piezasSprites;
    public Sprite[] piezas1;
    public Sprite[] piezas2;
    public Sprite[] piezas3;

    [Header("UI Atributes")]
    public bool inTutorial;
    public bool finished;
    public GameObject gameOverPanel;
    public GameObject tutorialPanel;

    private static gameManagerPuzzle instance;
    public static gameManagerPuzzle Instance
    {
        get
        {
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        tutorialPanel.SetActive(true);
        inTutorial = true;
        instance = this;
        gameOverPanel.SetActive(false);
        elegirPuzzle();
        ordenarPiezas();
    }


    void ordenarPiezas()
    {
        IDsAsignados.Clear();

        for (int i = 0; i < piezas.Count; i++)
        {
            
            int random = Random.Range(0, piezas.Count);
            while (IDsAsignados.Contains(random))
            {
                random = Random.Range(0, piezas.Count);
            }

            IDsAsignados.Add(random);

            piezas[random].GetComponent<SpriteRenderer>().sprite = piezasSprites[random];
            piezas[random].GetComponent<DragAndAdrop>().ID = random;
        }
    }

    public void checkWin()
    {
        for (int i = 0; i < gridPointScripts.Count; i++)
        {
            if (!gridPointScripts[i].tieneFichaBienPuesta)
            {
                return;
            }
        }

        displayGameOver();
    }

    private void elegirPuzzle()
    {
        Sprite[] piezasAntiguas = piezasSprites;
        int random = Random.Range(0, 3);
        switch (random)
        {
            case 0:
                piezasSprites = piezas1;
                break;
            case 1:
                piezasSprites = piezas2;
                break;
            case 2:
                piezasSprites = piezas3;
                break;
            default:
                piezasSprites = piezas1;
                break;
        }

        if (piezasSprites == piezasAntiguas)
            elegirPuzzle();
    }

    private void displayGameOver()
    {
        int aux = PlayerPrefs.GetInt("maxPuzzles", 0);
        aux++;
        PlayerPrefs.SetInt("maxPuzzles", aux);

        finished = true;
        audioManagerPuzzle.Instance.playAciertoSound();
        gameOverPanel.SetActive(true);
    }


    public void cambiarPuzzle()
    {
        ButtonSoundManager.Instance.playButtonSound();
        for (int i = 0; i < piezas.Count; i++)
        {
            piezas[i].GetComponent<DragAndAdrop>().resetPosicion();
        }

        elegirPuzzle();
        ordenarPiezas();

    }

    public void goPlay()
    {
        ButtonSoundManager.Instance.playButtonSound();
        inTutorial = false;
        tutorialPanel.SetActive(false);
    }

}
