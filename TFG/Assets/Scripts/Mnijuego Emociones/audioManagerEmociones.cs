using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManagerEmociones : MonoBehaviour
{
    [Header("Audio Clips")]
    public AudioClip audioAcierto;
    public AudioClip audioFallo;
    public float effectVolume;

    private AudioSource audioSource;

    private static audioManagerEmociones instance;
    public static audioManagerEmociones Instance
    {
        get
        {
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        effectVolume = PlayerPrefs.GetFloat("effectVolume", 0.05f);
        audioSource.volume = effectVolume;
    }


    public void playSonidoAcierto()
    {
        audioSource.clip = audioAcierto;
        audioSource.Play();
    }

    public void playSonidoFallo()
    {
        audioSource.clip = audioFallo;
        audioSource.Play();
    }
}
