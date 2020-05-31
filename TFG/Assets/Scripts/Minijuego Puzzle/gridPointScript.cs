using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridPointScript : MonoBehaviour
{
    [Header("Grid Point Atribute")]
    public int ID;
    public bool tieneFicha;
    public bool tieneFichaBienPuesta;

    public GameObject fichaGuardada;

    public void comprobarID(int ID)
    {
        tieneFicha = true;

        if(ID == this.ID)
        {
            tieneFichaBienPuesta = true;
            gameManagerPuzzle.Instance.checkWin();
        }
    }

    public void resetID()
    {
        tieneFicha = false;
        tieneFichaBienPuesta = false;
        fichaGuardada = null;
    }
}
