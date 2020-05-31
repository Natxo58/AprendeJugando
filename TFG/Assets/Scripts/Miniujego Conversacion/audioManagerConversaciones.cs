using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManagerConversaciones : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioClip sonidoButtonAnswerClip;
    private float effectVolume;

    private AudioSource audioSource;

    private static audioManagerConversaciones instance;
    public static audioManagerConversaciones Instance
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

    public void sonidoButtonAnswer()
    {
        audioSource.clip = sonidoButtonAnswerClip;
        audioSource.Play();
    }
}
