using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comprobarManzanaCaida : MonoBehaviour
{
    public GameObject cestaCollider;


    private void Start()
    {
        cestaCollider = GameObject.FindGameObjectWithTag("cestaCollider");
        gameObject.transform.parent = null;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Limite")
        {
            audioManagerManzanas.Instance.sonidoManzanaCaida();
            Destroy(gameObject);
        }

        if(collision.gameObject == cestaCollider)
        {
            audioManagerManzanas.Instance.sonidoManzanaRecogida();
            if (gameObject.tag == "dorada")
            {
                gameManagerManzanas.Instance.aumentarScoreDorada();
            }
            else
            {
                gameManagerManzanas.Instance.aumentarScore();
            }
            
            Destroy(gameObject);
        }
    }
}
