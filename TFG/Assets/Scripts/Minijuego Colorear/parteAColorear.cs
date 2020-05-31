using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class parteAColorear : MonoBehaviour
{
    [Header("Pieza Attributes")]
    public Text textoOperacion;
    public bool coloreada;
    public int resultado;
    public int num1;
    public int num2;

    private SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        calcularOperacion();
        sp = GetComponent<SpriteRenderer>();
    }

    void calcularOperacion()
    {
        int random = Random.Range(0, 2);

        if(random == 0)
        {
            Debug.Log("SUMA");
            num1 = Random.Range(0, 7);
            num2 = Random.Range(0, 7);
            while(num1 + num2 != resultado)
            {
                num1 = Random.Range(0, 7);
                num2 = Random.Range(0, 7);
            }

            actualizarTextoSuma();
        }
        else
        {
            Debug.Log("REsta");
            num1 = Random.Range(0, 7);
            num2 = Random.Range(0, 7);
            while (num1 - num2 != resultado)
            {
                num1 = Random.Range(0, 7);
                num2 = Random.Range(0, 7);
            }

            actualizarTextoResta();
        }
    }
    
    void actualizarTextoSuma()
    {
        textoOperacion.text = num1 + "+" + num2;
    }

    void actualizarTextoResta()
    {
        textoOperacion.text = num1 + "-" + num2;
    }

    public void resetParte()
    {
        coloreada = false;
        sp.color = Color.white;
        textoOperacion.enabled = true;
        calcularOperacion();
    }

}
