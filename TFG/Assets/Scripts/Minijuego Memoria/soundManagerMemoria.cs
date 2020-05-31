using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManagerMemoria : MonoBehaviour
{
    private AudioSource audioSource;
    private float effectVolume;

    [Header("AudioClips")]
    public AudioClip cartaDestapadaClip;
    public AudioClip cartaTapadaClip;
    public AudioClip aciertoClip;
    public AudioClip falloClip;

    private static soundManagerMemoria instance;
    public static soundManagerMemoria Instance
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

    public void playSoundCartasDestapada()
    {
        audioSource.clip = cartaDestapadaClip;
        audioSource.Play();
    }

    public void playSoundCartasTapada()
    {
        audioSource.clip = cartaTapadaClip;
        audioSource.Play();
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
