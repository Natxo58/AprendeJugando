using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManagerContar : MonoBehaviour
{
    private AudioSource audioSource;
    private float effectVolume;

    [Header("AudioClips")]
    public AudioClip aciertoClip;
    public AudioClip falloClip;

    private static audioManagerContar instance;
    public static audioManagerContar Instance
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
        audioSource.clip = aciertoClip;
        audioSource.Play();
    }

    public void playSoundFallo()
    {
        audioSource.clip = falloClip;
        audioSource.Play();
    }

}
