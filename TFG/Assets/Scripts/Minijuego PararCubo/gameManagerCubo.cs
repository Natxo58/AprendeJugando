using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManagerCubo : MonoBehaviour
{
    [Header("Colores")]
    public Color rojo;
    public Color amarillo;
    public Color verde;
    public Color gris;

    [SerializeField]
    List<Message> mensajes = new List<Message>();

    [Header("Dificult atributes")]
    private int dificultad = 0;
    public GameObject objetoDificultad1;
    public GameObject objetoDificultad2;
    public GameObject objetoDificultad3;
    public GameObject objetoDificultad4;
    public GameObject objetoDificultad5;
    public GameObject objetoDificultad6;


    public int maximaDificultad;
    public int minimaDificultad;

    [Header("UI atributes")]
    public GameObject tutorialPanel;


    [Header("Audio Clips")]
    private AudioSource audioSource;
    private float audioEffectVolume;
    public AudioClip startAumDificultadClip;
    public AudioClip stopDismDificultadClip;

    private static gameManagerCubo instance;
    public static gameManagerCubo Instance
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
        tutorialPanel.SetActive(true);
        instance = this;
        audioSource = GetComponent<AudioSource>();
        audioEffectVolume = PlayerPrefs.GetFloat("effectVolume", 0.15f);
        actualizarDificultad();
    }

    public void aumentarDificultad()
    {
        playSoundStartAumDificultad();
        if (dificultad < maximaDificultad)
        {
            dificultad++;
            actualizarDificultad();
        }

    }

    public void disminuirDificultad()
    {
        playSoundStopDismDificultad();
        if (dificultad > minimaDificultad)
        {
            dificultad--;
            actualizarDificultad();
        }

    }

    private void actualizarDificultad()
    {
        objetoDificultad1.SetActive(false);
        objetoDificultad2.SetActive(false);
        objetoDificultad3.SetActive(false);
        objetoDificultad4.SetActive(false);
        objetoDificultad5.SetActive(false);
        objetoDificultad6.SetActive(false);
        
        switch (dificultad)
        {
            case 1:
                objetoDificultad1.SetActive(true);
                break;
            case 2:
                objetoDificultad2.SetActive(true);
                break;
            case 3:
                objetoDificultad3.SetActive(true);
                break;
            case 4:
                objetoDificultad4.SetActive(true);
                break;
            case 5:
                objetoDificultad5.SetActive(true);
                break;
            case 6:
                objetoDificultad6.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void goPlay()
    {
        if (ButtonSoundManager.Instance != null)
        {
            ButtonSoundManager.Instance.playButtonSound();
        }
        tutorialPanel.SetActive(false);
        Time.timeScale = 1f;
    }


    public void playSoundStartAumDificultad()
    {
        audioSource.clip = startAumDificultadClip;
        audioSource.volume = audioEffectVolume;
        audioSource.Play();
    }

    public void playSoundStopDismDificultad()
    {
        audioSource.clip = startAumDificultadClip;
        audioSource.volume = audioEffectVolume;
        audioSource.Play();
    }
}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
}
