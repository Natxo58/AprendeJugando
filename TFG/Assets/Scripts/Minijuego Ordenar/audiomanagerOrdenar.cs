using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanagerOrdenar : MonoBehaviour
{
    private AudioSource audioSource;
    private float effectVolume;

    [Header("AudioClips")]
    public AudioClip colocarFichaClip;
    public AudioClip aciertoClip;
    public AudioClip falloClip;

    private static audiomanagerOrdenar instance;
    public static audiomanagerOrdenar Instance
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

    public void playColocarFicha()
    {
        audioSource.clip = colocarFichaClip;
        audioSource.Play();
    }

    public void playAciertoSound()
    {
        audioSource.clip = aciertoClip;
        audioSource.Play();
    }

    public void playFalloSound()
    {
        audioSource.clip = falloClip;
        audioSource.Play();
    }
}
