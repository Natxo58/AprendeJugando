using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanzarManzana : MonoBehaviour
{
    [Header("Manzana atributes")]
    public float force;

    private Rigidbody2D rb;
    private float directionX;
    private float directionY;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(Random.Range(0,2) == 1)
        {
            directionX = 1;
        }
        else
        {
            directionX = -1;
        }

        directionY = Random.Range(0f, 1f);
        force = Random.Range(5f, 10f);

        Vector2 direction = new Vector2(directionX, directionY);
        Debug.Log(direction);

        rb.AddForceAtPosition(direction * force, transform.position, ForceMode2D.Impulse);
    }
}
