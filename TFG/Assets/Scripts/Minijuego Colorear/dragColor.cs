using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragColor : MonoBehaviour
{
    [Header("Piece attriutes")]
    public bool isHeld;
    public int colorID;
    public SpriteRenderer sp;


    private Vector2 posicionInicial;
    private parteAColorear parteAColorear;
    private Color color;
    private BoxCollider2D box;
    


    public void OnMouseDown()
    {
        if (!PauseManager.Instance.isPaused())
        {
            isHeld = true;
            box.size = new Vector2(0.05f, 0.05f);
        }
    }

    public void OnMouseUp()
    {
        if (!PauseManager.Instance.isPaused())
        {
            isHeld = false;
            box.size = new Vector2(1.4f, 0.9f);
            if (parteAColorear == null)
            {
                resetPosicion();
            }
            else
            {
                comprobarMismoColor();
                resetPosicion();
            }
        }
    }

    private void Start()
    {
        color = sp.color;
        box = GetComponent<BoxCollider2D>();
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHeld && !PauseManager.Instance.isPaused())
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "parteColorear" && !collision.GetComponent<parteAColorear>().coloreada)
        {
            parteAColorear = collision.GetComponent<parteAColorear>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "parteColorear" && !collision.GetComponent<parteAColorear>().coloreada)
        {
            parteAColorear = null;
        }
    }

    private void comprobarMismoColor()
    {
        if (parteAColorear.resultado == colorID)
        {
            parteAColorear.GetComponent<SpriteRenderer>().color = color;
            parteAColorear.textoOperacion.enabled = false;
            parteAColorear.coloreada = true;
            AudioManagerColorear.Instance.playSoundAcierto();
            gameManagerColorear.Instance.checkWin();
        }
        else
        {
            AudioManagerColorear.Instance.playSoundFallo();
        }
    }
    
    public void resetPosicion()
    {
        transform.position = posicionInicial;
    }

    public void resetParteColorear()
    {
        parteAColorear = null;
    }
}
