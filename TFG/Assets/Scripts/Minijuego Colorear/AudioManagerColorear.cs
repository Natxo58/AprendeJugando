using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerColorear : MonoBehaviour
{
    private AudioSource audioSource;
    private float effectVolume;

    [Header("AudioClips")]
    public AudioClip sonidoPintura;
    public AudioClip falloClip;

    private static AudioManagerColorear instance;
    public static AudioManagerColorear Instance
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
        audioSource.clip = sonidoPintura;
        audioSource.Play();
    }

    public void playSoundFallo()
    {
        audioSource.clip = falloClip;
        audioSource.Play();
    }
}
