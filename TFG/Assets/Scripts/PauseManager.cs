using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject pauseMenu;
    private bool paused;

    private static PauseManager instance;
    public static PauseManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Start()
    {
        instance = this;
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        paused = !paused;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        ButtonSoundManager.Instance.playButtonSound();
        paused = !paused;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void VolverMenuPausa()
    {
        ButtonSoundManager.Instance.playButtonSound();
        Resume();
        SceneController.Instance.cargarMenuPrincipal();
    }

    public void SalirPausa()
    {
        ButtonSoundManager.Instance.playButtonSound();
        SceneController.Instance.exitGame();
    }

    public bool isPaused()
    {
        return paused;
    }

}
