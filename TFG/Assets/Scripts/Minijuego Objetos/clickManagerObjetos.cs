using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickManagerObjetos : MonoBehaviour
{
    public float rayLenght;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !PauseManager.Instance.isPaused() && !gameManagerObjetos.Instance.inTutorial && !gameManagerObjetos.Instance.finished && !gameManagerObjetos.Instance.comprobando)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, rayLenght);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.GetComponent<objetoScript>() != null)
                    hit.collider.gameObject.GetComponent<objetoScript>().seleccionarObjeto();
            }
        }
    }
}
