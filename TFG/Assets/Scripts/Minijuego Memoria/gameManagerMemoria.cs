using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerMemoria : MonoBehaviour
{
    private static gameManagerMemoria instance;
    public static gameManagerMemoria Instance
    {
        get
        {
            return instance;
        }
    }

    [Header("cartas atributes")]
    public List<GameObject> cartas;
    public List<GameObject> cartasTotales;
    public List<GameObject> cartasRestantes;
    public Sprite[] dorsos;
    public Sprite[] dorsosDif1;
    public Sprite[] dorsosDif2;
    public Sprite[] dorsosDif3;
    public Sprite[] dorsosDif4;
    private List<GameObject> cartasAAsignar;
    private List<GameObject> cartasSeleccionadas = new List<GameObject>();


    [Header("Game Manager Atributes")]
    public int dificultad = 0;
    public bool inMenu;
    public GameObject[] niveles;
    public GameObject gameOverPanel;
    public GameObject tutorialPanel;
    private int idActual;
    


    // Start is called before the first frame update
    void Start()
    {
        inMenu = true;
        dorsos = dorsosDif1;
        gameOverPanel.SetActive(false);
        tutorialPanel.SetActive(true);
        instance = this;
        buscarCartas();
        asignarIdsCartas();
    }

    private void buscarCartas()
    {
        limpiarListas();
        GameObject[] cartasGameObject = GameObject.FindGameObjectsWithTag("Carta");
        for (int i = 0; i < cartasGameObject.Length; i++)
        {
            cartas.Add(cartasGameObject[i]);
            cartasTotales.Add(cartasGameObject[i]);
            cartasRestantes.Add(cartasGameObject[i]);
        }
    }

    private void asignarIdsCartas()
    {
        cartasAAsignar = cartas;
        idActual = 0;

        int iteraciones1 = 0;
        int iteraciones2 = 0;
        while(cartasAAsignar.Count > 0 || iteraciones1 > 100)
        {
            GameObject carta1 = cartasAAsignar[Random.Range(0, cartasAAsignar.Count)];
            GameObject carta2 = cartasAAsignar[Random.Range(0, cartasAAsignar.Count)];

            while(carta1 == carta2 || iteraciones2 > 100)
            {
                carta1 = cartasAAsignar[Random.Range(0, cartasAAsignar.Count)];
                carta2 = cartasAAsignar[Random.Range(0, cartasAAsignar.Count)];
                iteraciones2++;
            }

            carta1.GetComponent<CartaScript>().IDCarta = idActual;
            carta2.GetComponent<CartaScript>().IDCarta = idActual;
            carta1.GetComponent<CartaScript>().setContenido(dorsos[idActual]);
            carta2.GetComponent<CartaScript>().setContenido(dorsos[idActual]);

            cartasAAsignar.Remove(carta1);
            cartasAAsignar.Remove(carta2);

            iteraciones1++;
            idActual++;
        }
    }

    public void añadirCarta(GameObject carta)
    {
        cartasSeleccionadas.Add(carta);
        if (cartasSeleccionadas.Count >= 2)
        {
            for (int i = 0; i < cartasTotales.Count; i++)
            {
                cartasTotales[i].GetComponent<CartaScript>().comprobando = true;
            }
            Invoke("comprobarCartasIguales", 1f);
        }
            
    }

    public void elminarCarta(GameObject carta)
    {
        if(cartasSeleccionadas.Contains(carta))
            cartasSeleccionadas.Remove(carta);
    }

    public void comprobarCartasIguales()
    {
        GameObject carta1 = cartasSeleccionadas[0];
        GameObject carta2 = cartasSeleccionadas[1];

        CartaScript carta1s = carta1.GetComponent<CartaScript>();
        CartaScript carta2s = carta2.GetComponent<CartaScript>();

        if (carta1s.IDCarta == carta2s.IDCarta)
        {
            soundManagerMemoria.Instance.playSoundAcierto();
            carta1s.setAcertada(true);
            carta2s.setAcertada(true);

            cartasRestantes.Remove(carta1);
            cartasRestantes.Remove(carta2);

            checkGameOver();

            for (int i = 0; i < cartasTotales.Count; i++)
            {
                cartasTotales[i].GetComponent<CartaScript>().comprobando = false;
            }
        }
        else
        {
            soundManagerMemoria.Instance.playSoundFallo();
            for (int i = 0; i < cartasTotales.Count; i++)
            {
                cartasTotales[i].GetComponent<CartaScript>().comprobando = false;
            }

            carta1s.darVuelta();
            carta2s.darVuelta();
        }

        cartasSeleccionadas.Clear();
        
    }

    public void aumentarDificultad()
    {
        ButtonSoundManager.Instance.playButtonSound();
        resetearCartas();
        niveles[dificultad].SetActive(false);
        dificultad++;
        dificultad = Mathf.Clamp(dificultad, 0, niveles.Length - 1);
        niveles[dificultad].SetActive(true);
        cambiarContenido();
        buscarCartas();
        asignarIdsCartas();
    }

    public void disminuirDificultad()
    {
        ButtonSoundManager.Instance.playButtonSound();
        resetearCartas();
        niveles[dificultad].SetActive(false);
        dificultad--;
        dificultad = Mathf.Clamp(dificultad, 0, niveles.Length - 1);
        niveles[dificultad].SetActive(true);
        cambiarContenido();
        buscarCartas();
        asignarIdsCartas();
    }

    private void limpiarListas()
    {
        cartasRestantes.Clear();
        cartasTotales.Clear();
        cartas.Clear();
        cartasSeleccionadas.Clear();
    }

    private void checkGameOver()
    {
        if(cartasRestantes.Count <= 0)
        {
            displayGameOver();
        }
    }

    private void displayGameOver()
    {
        if(dificultad + 1 > PlayerPrefs.GetInt("maxMemoria", 0))
        {
            PlayerPrefs.SetInt("maxMemoria", dificultad + 1);
        }
        gameOverPanel.SetActive(true);
    }

    public void goPlay()   
    {
        inMenu = false;
        ButtonSoundManager.Instance.playButtonSound();
        tutorialPanel.SetActive(false);
    }

    private void resetearCartas()
    {
        for (int i = 0; i < cartasTotales.Count; i++)
        {
            cartasTotales[i].GetComponent<CartaScript>().resetearCarta();
        }
    }


    private void cambiarContenido()
    {
        switch (dificultad)
        {
            case 0:
                dorsos = dorsosDif1;
                break;
            case 1:
                dorsos = dorsosDif2;
                break;
            case 2:
                dorsos = dorsosDif3;
                break;
            case 3:
                dorsos = dorsosDif4;
                break;
            default:
                dorsos = dorsosDif1;
                break;
        }
    }

}
