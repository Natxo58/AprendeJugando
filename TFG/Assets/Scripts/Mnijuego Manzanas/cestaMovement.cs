using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cestaMovement : MonoBehaviour
{
    [Header("Cesta atributes")]
    public float speed;
    public Transform limiteIzq;
    public Transform limiteDrch;

    private float moveInput;
    private Rigidbody2D rb;
    private bool allowMovement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (transform.position.x > limiteDrch.position.x)
            transform.position = limiteDrch.position;
        if (transform.position.x < limiteIzq.position.x)
            transform.position = limiteIzq.position;

        rb.velocity = new Vector2(moveInput * speed, 0);
         
    }
}
