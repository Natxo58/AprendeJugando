using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndAdrop : MonoBehaviour
{
    [Header("Piece attriutes")]
    public bool colocada;
    public int ID = -1;
    public bool isHeld;
    private Vector2 posicionInicial;
    private GameObject hueco;


    [Header("Grid Atributes")]
    private float distanciaMinimaUnion;
    public Transform[] gridPoints;

    private void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        if (isHeld && !PauseManager.Instance.isPaused())
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }

    public void OnMouseDown()
    {
        if (!PauseManager.Instance.isPaused() && !gameManagerPuzzle.Instance.finished && !gameManagerPuzzle.Instance.inTutorial)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 10;
            isHeld = true;
        }
    }

    public void OnMouseUp()
    {
        if (!PauseManager.Instance.isPaused() && !gameManagerPuzzle.Instance.finished && !gameManagerPuzzle.Instance.inTutorial)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 0;
            isHeld = false;

            if (hueco != null && !hueco.GetComponent<gridPointScript>().tieneFicha)
            {
                audioManagerPuzzle.Instance.playColocarFicha();
                hueco.GetComponent<gridPointScript>().comprobarID(ID);
                transform.position = hueco.transform.position;
            }
            else
            {
                resetPosicion();
            }

        }
    }

    public void resetPosicion()
    {
        colocada = false;
        transform.position = posicionInicial;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "grid")
        {
            hueco = collision.gameObject;
            if (!hueco.GetComponent<gridPointScript>().fichaGuardada)
            {
                colocada = true;
                hueco.GetComponent<gridPointScript>().fichaGuardada = gameObject;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "grid")
        {
            hueco = collision.gameObject;
            if (!hueco.GetComponent<gridPointScript>().fichaGuardada)
            {
                colocada = true;
                hueco.GetComponent<gridPointScript>().fichaGuardada = gameObject;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "grid")
        {
            hueco = collision.gameObject;
            if (hueco.GetComponent<gridPointScript>().fichaGuardada == gameObject)
            {
                colocada = false;
                hueco.GetComponent<gridPointScript>().resetID();
                hueco = null;
            }
        }
    }


}
