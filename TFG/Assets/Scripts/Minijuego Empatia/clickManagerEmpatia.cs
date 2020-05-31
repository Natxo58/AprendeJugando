using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickManagerEmpatia : MonoBehaviour
{
    public float rayLenght;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !PauseManager.Instance.isPaused() && !gameManagerEmpatia.Instance.inTutorial && !gameManagerEmpatia.Instance.finished && !gameManagerEmpatia.Instance.comprobando)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, rayLenght);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.GetComponent<empatiaScript>() != null)
                    hit.collider.gameObject.GetComponent<empatiaScript>().seleccionarEmpatia();
            }
        }
    }
}
