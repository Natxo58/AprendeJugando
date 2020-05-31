using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundManager : MonoBehaviour
{
    private static ButtonSoundManager instance = null;
    public static ButtonSoundManager Instance
    {
        get { return instance; }
    }

    public AudioClip buttonSound;
    AudioSource AudioSource;

    void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
        AudioSource.clip = buttonSound;

        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("effectVolume");

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        
        DontDestroyOnLoad(this.gameObject);
    }

    public void playButtonSound()
    {
        AudioSource.volume = PlayerPrefs.GetFloat("effectVolume", 0.15f);
        AudioSource.Play();
    }

}
