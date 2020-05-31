using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickManager : MonoBehaviour
{
    public float rayLenght;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, rayLenght);

            if(hit.collider != null)
            {
                if(hit.collider.gameObject.GetComponent<CartaScript>() != null)
                    hit.collider.gameObject.GetComponent<CartaScript>().darVuelta();
            }
        }
    }
}
