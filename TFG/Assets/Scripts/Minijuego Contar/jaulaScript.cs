using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jaulaScript : MonoBehaviour
{
    [Header("Animal attributes")]
    public int animalesTotales;
    public InputField inputField;
    public GameObject acertado;

    [Header("Spawn Points")]
    public GameObject[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        spawnAnimales();
    }

    void spawnAnimales()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int random = Random.Range(0, 2);
            if(random == 0)
            {
                spawnPoints[i].SetActive(true);
                animalesTotales++;
            }
        }
    }

    public void comprobarNumero()
    {
        int numero = int.Parse(inputField.text);
        if(numero == animalesTotales)
        {
            displayCorrectNumber();
        }
        else
        {
            audioManagerContar.Instance.playSoundFallo();
            inputField.text = "";
        }
    }

    private void displayCorrectNumber()
    {
        inputField.gameObject.SetActive(false);
        acertado.SetActive(true);
        audioManagerContar.Instance.playSoundAcierto();
        gameManagerContar.Instance.checkGameOver();
    }

    public void resetLevel()
    {
        animalesTotales = 0;
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i].SetActive(false);

            int random = Random.Range(0, 2);
            if (random == 0)
            {
                spawnPoints[i].SetActive(true);
                animalesTotales++;
            }
        }

        inputField.gameObject.SetActive(true);
        inputField.text = "";
        acertado.SetActive(false);

    }

}
