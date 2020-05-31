using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secuenciaEmpatiaScript : MonoBehaviour
{
    public string emocionExpresada;
    public GameObject texto;

    public void activarTexto()
    {
        texto.SetActive(true);
    }

    public void desactivarTexto()
    {
        texto.SetActive(false);
    }

}
