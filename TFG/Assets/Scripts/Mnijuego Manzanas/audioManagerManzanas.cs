using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManagerManzanas : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioClip manzanaCaida;
    public AudioClip manzanaRecogida;
    private float effectVolume;

    private AudioSource audioSource;

    private static audioManagerManzanas instance;
    public static audioManagerManzanas Instance
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

    public void sonidoManzanaRecogida()
    {
        audioSource.clip = manzanaRecogida;
        audioSource.Play();
    }

    public void sonidoManzanaCaida()
    {
        audioSource.clip = manzanaCaida;
        audioSource.Play();
    }
}
