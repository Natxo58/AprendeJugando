using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaScript : MonoBehaviour
{
    [Header("Carta Atributes")]
    public Sprite dorso;
    public Sprite contenido;
    public bool destapada;
    public bool acertada;
    public bool comprobando;
    public int IDCarta;

    private List<GameObject> cartasSeleccionadas = new List<GameObject>();
    private SpriteRenderer sp;
    private Vector2 posicionInicial;

    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void darVuelta()
    {
        if (!acertada && !comprobando &&!PauseManager.Instance.isPaused() && !gameManagerMemoria.Instance.inMenu){
            destapada = !destapada;

            if (destapada)
            {
                soundManagerMemoria.Instance.playSoundCartasDestapada();
                cogerCarta();
            }
            else
            {
                soundManagerMemoria.Instance.playSoundCartasTapada();
                dejarCarta();
            }
        }
    }

    public void cogerCarta()
    {
        gameManagerMemoria.Instance.añadirCarta(gameObject);
        sp.sprite = contenido;
    }

    public void dejarCarta()
    {
        gameManagerMemoria.Instance.elminarCarta(gameObject);
        sp.sprite = dorso;
    }

    public void setContenido(Sprite sprite)
    {
        contenido = sprite;
    }

    public void resetearCarta()
    {
        destapada = false;
        acertada = false;
        comprobando = false;
        IDCarta = -1;
        sp.sprite = dorso;
    }

    #region Getters & Setters

    public void setSprite(Sprite sprite)
    {
        sp.sprite = sprite;
    }

    public Sprite getSprite()
    {
        return sp.sprite;
    }

    public void setAcertada(bool b)
    {
        acertada = b;
    }

    public bool getAcertada()
    {
        return acertada;
    }

    
    #endregion
}
