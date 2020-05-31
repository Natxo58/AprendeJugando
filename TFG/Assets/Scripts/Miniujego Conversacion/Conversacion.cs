using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Conversacion
{
    public string texto;
    public Contestacion[] contestaciones;


    public Contestacion contestacionRandom()
    {
        return contestaciones[Random.Range(0, contestaciones.Length)];
    }
}
