using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragFotoFrases : MonoBehaviour
{
    private bool colocada;
    private GameObject hueco;
    private SpriteRenderer sp;

    [Header("Drag atributes")]
    public Vector2 posicionInicial;
    public bool isHeld;

    // Start is called before the first frame update
    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
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

    public void OnMouseDown()
    {
        if (!PauseManager.Instance.isPaused() && !gameManagerOrdenar.Instance.finished && !gameManagerOrdenar.Instance.inTutorial)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 10;
            isHeld = true;
        }
    }

    public void OnMouseUp()
    {
        if (!PauseManager.Instance.isPaused() && !gameManagerOrdenar.Instance.finished && !gameManagerOrdenar.Instance.inTutorial)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 0;
            isHeld = false;

            if (colocada)
            {
                audiomanagerOrdenar.Instance.playColocarFicha();
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
        if(collision.tag == "cartaComprobar")
        {
            hueco = collision.gameObject;
            if (!hueco.GetComponent<huecoScript>().fotoGuardada)
            {
                colocada = true;
                hueco.GetComponent<huecoScript>().fotoGuardada = gameObject;
                hueco.GetComponent<huecoScript>().ordenGuardado = gameObject.GetComponent<FotosScript>().orden;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "cartaComprobar" && hueco.GetComponent<huecoScript>().fotoGuardada == gameObject)
        {
            colocada = false;
            collision.GetComponent<huecoScript>().resetOrden();
            hueco = null;
        }
    }

}
