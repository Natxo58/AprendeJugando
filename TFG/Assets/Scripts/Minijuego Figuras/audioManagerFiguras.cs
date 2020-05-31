using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManagerFiguras : MonoBehaviour
{
    private AudioSource audioSource;
    private float effectVolume;

    [Header("AudioClips")]
    public AudioClip sonidoAcierto;
    public AudioClip sonidoFallo;

    private static audioManagerFiguras instance;
    public static audioManagerFiguras Instance
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

    public void playSoundAcierto()
    {
        audioSource.clip = sonidoAcierto;
        audioSource.Play();
    }

    public void playSoundFallo()
    {
        audioSource.clip = sonidoFallo;
        audioSource.Play();
    }
}
