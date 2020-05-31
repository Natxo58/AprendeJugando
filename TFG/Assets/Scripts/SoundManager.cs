using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    //Play Global
    private static SoundManager instance = null;
    public static SoundManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("musicVolume");
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

}
