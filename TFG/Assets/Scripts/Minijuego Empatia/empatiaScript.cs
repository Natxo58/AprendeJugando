using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class empatiaScript : MonoBehaviour
{
    public bool seleccionado;
    public string emocionOpcion;

    [Header("Sprites Atributes")]
    public Sprite spriteSinMarcado;
    public Sprite spriteMarcado;

    public void seleccionarEmpatia()
    {
        seleccionado = !seleccionado;
        if (seleccionado)
        {
            GetComponent<SpriteRenderer>().sprite = spriteMarcado;
            gameManagerEmpatia.Instance.comprobarEmocion(emocionOpcion);
        }
        else
            GetComponent<SpriteRenderer>().sprite = spriteSinMarcado;
    }

    public void resetEmpatia()
    {
        seleccionado = false;
        GetComponent<SpriteRenderer>().sprite = spriteSinMarcado;
    }
}
