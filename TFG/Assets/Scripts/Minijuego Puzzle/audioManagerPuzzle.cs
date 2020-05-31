using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManagerPuzzle : MonoBehaviour
{
    private AudioSource audioSource;
    private float effectVolume;

    [Header("AudioClips")]
    public AudioClip colocarFichaClip;
    public AudioClip soundAciertoClip;

    private static audioManagerPuzzle instance;
    public static audioManagerPuzzle Instance
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
        audioSource.clip = soundAciertoClip;
        audioSource.Play();
    }
}
