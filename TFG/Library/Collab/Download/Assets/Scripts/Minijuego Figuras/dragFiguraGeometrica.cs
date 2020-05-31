using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragFiguraGeometrica : MonoBehaviour
{
    [Header("Drag atributes")]
    public Vector2 posicionInicial;
    public bool isHeld;

    [Space]
    [Header("Hueco Atributes")]
    public GameObject huecoCorrespondiente;
    public bool enHuecoCorrespondiente;

    // Start is called before the first frame update
    void Start()
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
        if (!PauseManager.Instance.isPaused() && !enHuecoCorrespondiente)
        {
            isHeld = true;
        }
    }

    public void OnMouseUp()
    {
        if (!PauseManager.Instance.isPaused())
        {
            isHeld = false;
            if (enHuecoCorrespondiente)
            {
                transform.position = huecoCorrespondiente.transform.position;
                gameManagerFiguras.Instance.CheckGameOver();
            }
            else
            {
                transform.position = posicionInicial;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == huecoCorrespondiente)
        {
            enHuecoCorrespondiente = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == huecoCorrespondiente)
        {
            enHuecoCorrespondiente = false;
        }
    }
}
