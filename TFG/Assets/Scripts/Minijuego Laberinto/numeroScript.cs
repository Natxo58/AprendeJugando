using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numeroScript : MonoBehaviour
{
    [Header("Sprites Numeros")]
    public Sprite[] spritesNumeros;

    public int numeroRepresenta;
    private SpriteRenderer sp;

    // Start is called before the first frame update
    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    public void cambiarNumero(int n)
    {
        numeroRepresenta = n;
        switch (numeroRepresenta){
            case 0:
                sp.sprite = spritesNumeros[0];
                break;
            case 1:
                sp.sprite = spritesNumeros[1];
                break;
            case 2:
                sp.sprite = spritesNumeros[2];
                break;
            case 3:
                sp.sprite = spritesNumeros[3];
                break;
            case 4:
                sp.sprite = spritesNumeros[4];
                break;
            case 5:
                sp.sprite = spritesNumeros[5];
                break;
            case 6:
                sp.sprite = spritesNumeros[6];
                break;
            case 7:
                sp.sprite = spritesNumeros[7];
                break;
            case 8:
                sp.sprite = spritesNumeros[8];
                break;
            case 9:
                sp.sprite = spritesNumeros[9];
                break;
            default:
                Debug.Log("Esto no va");
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("xd");
            if(collision.name == "ColliderPeces")
                collision.GetComponent<cogerNumeros>().calculatePeces(gameObject);
        }
    }
}
