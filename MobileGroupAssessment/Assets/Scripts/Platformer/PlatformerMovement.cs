using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float jumpSpeed = 1.0f;
    bool grounded = false;
    public int jumpCount = 0;
    public int maxJumps = 2;
    Animator anim;
    float moveX = 0;
    public Joystick joystick;
    private bool facingRight = true;

    public bool dir;

    void Start()
    {
        anim = GetComponent<Animator>();
        GetComponent<SpriteRenderer>().flipX = true;
    }

    void Update()
    {
        if (joystick.Horizontal >= 0.2f)
        {
            moveX = 1;
            Debug.Log("R" + moveX);
        }
        else if (joystick.Horizontal <= -0.2f)
        {
            moveX = -1;
            Debug.Log("L" + moveX);
        }
        else
        {
            moveX = 0;
            Debug.Log("N" + moveX);
        }
        if (joystick.Vertical >= 0.2f)
        {
            jumpSpeed = 1.3f;
            Jump();
        }
        else
        {
            jumpSpeed = 0.0f;
        }
        float x = joystick.Horizontal;
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = moveX * moveSpeed;
        GetComponent<Rigidbody2D>().velocity = velocity;
        if (x == 0)
        {
            anim.SetInteger("x", 0);
        }
        else
        {
            anim.SetInteger("x", 1);
        }
        if(velocity.y > 0)
        {
            anim.SetInteger("y", 1);
        }
        else if (velocity.y < 0)
        {
            anim.SetInteger("y", -1);
        }
        else
        {
            anim.SetInteger("y", 0);
        }
        if (x > 0 && dir == false)
        {
            Flip();
            dir = true;
        }
        else if (x < 0 && dir == true)
        {
            Flip();
            dir = false;
        }

    }
    public void Jump()
    {
        if (jumpCount < maxJumps)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100 * jumpSpeed));
            jumpCount++;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            grounded = true;
            jumpCount = 0;
            anim.SetBool("grounded", grounded);
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            grounded = true;
            jumpCount = 0;
            anim.SetBool("grounded", grounded);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            grounded = false;
            anim.SetBool("grounded", grounded);
        }
    }

    public void MoveLeft()
    {
        moveX = -1;
    }

    public void MoveRight()
    {
        moveX = 1;
    }

    public void StopMove()
    {
        moveX = 0;
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        /*
        float x = Input.GetAxisRaw("Horizontal");
        if (x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }*/
    }

}
