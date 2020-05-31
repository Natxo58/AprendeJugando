using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static SceneController instance;
    public static SceneController Instance
    {
        get
        {
            return instance;
        }
    }

    private void Start()
    {
        instance = this;
    }
       

    public void cargarMenuPrincipal()
    {
        if(Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }

        playButtonSound();
        SceneManager.LoadScene("Menu Principal");
    }

    public void cargarMinijuegoEmociones()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }

        playButtonSound();
        SceneManager.LoadScene("Minijuego Emociones nv1");
    }

    public void cargarMinijuegoReflejos()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }

        playButtonSound();
        SceneManager.LoadScene("Minijuego Reflejos");
    }

    public void cargarMinijuegoManzanas()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }

        playButtonSound();
        SceneManager.LoadScene("Minijuego Manzanas");
    }

    public void cargarMinijuegoPuertas()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }

        playButtonSound();
        SceneManager.LoadScene("Minijuego Puertas");
    }

    public void cargarMinijuegoConversacion()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }

        playButtonSound();
        SceneManager.LoadScene("Minijuego Conversacion");
    }

    public void cargarMinijuegosAcademicos()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }

        playButtonSound();
        SceneManager.LoadScene("Minijuegos Academicos");
    }

    public void cargarMinijuegosFisicos()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }

        playButtonSound();
        SceneManager.LoadScene("Minijuegos Fisicos");
    }

    public void cargarMinijuegosSociales()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }

        playButtonSound();
        SceneManager.LoadScene("Minijuegos Sociales");
    }

    public void cargarMinijuegoMemoria()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }

        playButtonSound();
        SceneManager.LoadScene("Minijuego Memoria");
    }

    public void cargarMinijuegoPuzzle()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }

        playButtonSound();
        SceneManager.LoadScene("Minijuego Puzzle");
    }

    public void cargarMinijuegoColorear()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }

        playButtonSound();
        SceneManager.LoadScene("Minijuego Colorear");
    }

    public void cargarMinijuegoContar()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }

        playButtonSound();
        SceneManager.LoadScene("Minijuego Contar");
    }

    public void cargarMinijuegoLaberinto()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }

        playButtonSound();
        SceneManager.LoadScene("Minijuego Laberinto");
    }

    public void cargarMinijuegoOrdenar()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }

        playButtonSound();
        SceneManager.LoadScene("Minijuego Ordenar");
    }

    public void cargarMinijuegoFiguras()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }

        playButtonSound();
        SceneManager.LoadScene("Minijuego Figuras");
    }

    public void cargarMinijuegoObjetos()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }

        playButtonSound();
        SceneManager.LoadScene("Minijuego Objetos");
    }

    public void cargarMinijuegoEmpatia()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }

        playButtonSound();
        SceneManager.LoadScene("Minijuego Empatia");
    }

    public void cargarSeleccionMinijuegos()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }

        playButtonSound();
        SceneManager.LoadScene("Seleccion Minijuego");
    }

    public void cargarTutorial()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }

        playButtonSound();
        SceneManager.LoadScene("Tutorial");
    }

    public void cargarOpciones()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }

        playButtonSound();
        SceneManager.LoadScene("Opciones");
    }

    public void restartScene()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }

        playButtonSound();

        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }

    public void exitGame()
    {
        playButtonSound();
        Application.Quit();
    }

    void playButtonSound()
    {
        ButtonSoundManager.Instance.playButtonSound();
    }

}
