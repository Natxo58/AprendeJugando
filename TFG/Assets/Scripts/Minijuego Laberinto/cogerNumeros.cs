using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cogerNumeros : MonoBehaviour
{
    public int suma;

    public GameObject player;
    private List<int> numerosRecogidos = new List<int>();

    private void Start()
    {
        gameObject.SetActive(true);
        numerosRecogidos.Clear();
    }

    public void calculatePeces(GameObject collision)
    {
        if (collision.tag == "Numero")
        {
            suma += collision.gameObject.GetComponent<numeroScript>().numeroRepresenta;
            numerosRecogidos.Add(collision.gameObject.GetComponent<numeroScript>().numeroRepresenta);
            Destroy(collision.gameObject);
            audioManagerLaberinto.Instance.playSoundRecoger();
        }
        else
        {
            if (collision.tag == "Goal")
            {
                gameObject.SetActive(false);
                gameManagerLaberinto.Instance.displayGameOver(numerosRecogidos);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Goal")
        {
            player.SetActive(false);
            gameManagerLaberinto.Instance.displayGameOver(numerosRecogidos);
        }
    }
}
