using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCharacterLaberinto : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Animator anim;

    private Vector2 moveVelocity;
    private float moveInputHorizontal;
    private float moveInputVertical;

    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManagerLaberinto.Instance.gameOver && !gameManagerLaberinto.Instance.tutorialDisplayed)
        {
            moveInputHorizontal = Input.GetAxisRaw("Horizontal");
            moveInputVertical = Input.GetAxisRaw("Vertical");
            Vector2 moveInput = new Vector2(moveInputHorizontal, moveInputVertical);
            moveVelocity = moveInput.normalized * speed;
        }

        testAnimation();

        if(facingRight == false && moveInputHorizontal > 0)
            Flip();
        else
            if (facingRight == true && moveInputHorizontal < 0)
                Flip();
    }

    private void FixedUpdate()
    {
        if (!gameManagerLaberinto.Instance.gameOver)
        {
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void testAnimation()
    {
        if (moveInputHorizontal != 0 || moveInputVertical != 0)
            anim.SetBool("isMoving", true);
        else
            anim.SetBool("isMoving", false);
    }
}
