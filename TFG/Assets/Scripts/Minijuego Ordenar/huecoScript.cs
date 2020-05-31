using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huecoScript : MonoBehaviour
{
    [Header("Orden Atributes")]
    public int ordenGuardado;
    public int orderCorrecto;
    public LayerMask layerFoto;

    [Space]
    [Header("Fotos Atributes")]
    public GameObject fotoGuardada;

    public bool fotoCorrecta()
    {
        Debug.Log(ordenGuardado == orderCorrecto);
        return ordenGuardado == orderCorrecto;
    }

    public void resetOrden()
    {
        ordenGuardado = -1;
        fotoGuardada = null;
    }

    public void devolverFotosErroneasPosicionInicial()
    {
        if(ordenGuardado != orderCorrecto)
        {
            if(fotoGuardada != null)
                fotoGuardada.GetComponent<dragFotoFrases>().resetPosicion();
            audiomanagerOrdenar.Instance.playFalloSound();
            resetOrden();
        }
    }

    public void comprobarFotoPuesta()
    {
        Collider2D coll = Physics2D.OverlapBox(gameObject.transform.position, new Vector2(1, 1), Mathf.PI, layerFoto);
        if (fotoGuardada == null)
            if (coll != null)
            {
                fotoGuardada = coll.gameObject;
                ordenGuardado = fotoGuardada.GetComponent<FotosScript>().orden;
                devolverFotosErroneasPosicionInicial();
            }
    }
}
