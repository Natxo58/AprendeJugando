using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    AudioSource audio;

    public Slider musicSlider;
    public Slider effectsSlider;

    float musicVolume;
    float effectVolume;

    // Start is called before the first frame update
    void Awake()
    {
        audio = GameObject.Find("musicManager").GetComponent<AudioSource>();

        musicSlider.value = PlayerPrefs.GetFloat("musicVolume", 0.05f);
        musicVolume = PlayerPrefs.GetFloat("musicVolume", 0.05f);

        effectsSlider.value = PlayerPrefs.GetFloat("effectVolume", 0.05f);
        effectVolume = PlayerPrefs.GetFloat("effectVolume", 0.05f); 
    }

    // Update is called once per frame
    void Update()
    {
        if (audio != null)
            audio.volume = musicVolume;
    }

    public void SetMusicVolume()
    {
        musicVolume = musicSlider.value;
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
    }


    public void SetEffectVolume()
    {
        effectVolume = effectsSlider.value;
        PlayerPrefs.SetFloat("effectVolume", effectVolume);
    }
}
