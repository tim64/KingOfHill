using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isGround;
    private Rigidbody2D rb2d;

    private bool jump;
    private Vector2 jumpVector;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb2d.gravityScale = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            rb2d.gravityScale = 0;
            isGround = true;
        }
    }

    void FixedUpdate()
    {
        if (jump)
        {
            rb2d.AddForce(Vector3.Normalize((Vector2)transform.position - jumpVector), ForceMode2D.Impulse);
            jump = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGround = false;
            rb2d.gravityScale = 1;
        }
    }

    public void VectorJump(Vector2 vector)
    {
        jumpVector = vector;
        jump = true; 
    }
}
