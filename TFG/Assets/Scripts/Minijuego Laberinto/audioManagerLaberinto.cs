using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManagerLaberinto : MonoBehaviour
{
    private AudioSource audioSource;
    private float effectVolume;

    [Header("AudioClips")]
    public AudioClip sonidoRecoger;
    public AudioClip sonidoGanar;
    public AudioClip sonidoPerder;

    private static audioManagerLaberinto instance;
    public static audioManagerLaberinto Instance
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

    public void playSoundRecoger()
    {
        audioSource.clip = sonidoRecoger;
        audioSource.Play();
    }

    public void playSoundGanar()
    {
        audioSource.clip = sonidoGanar;
        audioSource.Play();
    }

    public void playSoundPerder()
    {
        audioSource.clip = sonidoPerder;
        audioSource.Play();
    }
}
