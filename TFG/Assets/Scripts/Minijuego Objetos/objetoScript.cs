using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetoScript : MonoBehaviour
{
    public bool objetoCorrecto;
    public bool seleccionado;
    public GameObject spriteSeleccionado;

    public void seleccionarObjeto()
    {
        audioManagerObjetos.Instance.playSoundSeleccionar();

        seleccionado = !seleccionado;
        spriteSeleccionado.SetActive(!spriteSeleccionado.activeSelf);

        if (seleccionado)
            gameManagerObjetos.Instance.seleccionarObjeto(gameObject);
        else
            gameManagerObjetos.Instance.deseleccionarObjeto(gameObject);
    }
}
