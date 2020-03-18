using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float jumpForce;
    public bool onGround;
    public bool isJumping;
    public float jumpTime;
    public float speed;

    private Rigidbody2D rb;
    private float jumpTimeCounter;
    private float moveInput;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onGround || isJumping)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector2.up * jumpForce;
                isJumping = true;
                onGround = false;
                jumpTimeCounter = jumpTime;
            }
        }

        if (Input.GetKey(KeyCode.Space) && isJumping && !onGround)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

    }

    public void TriggerFan(float fanPower)
    {
        rb.AddForce(new Vector2(0, 1) * fanPower, ForceMode2D.Force);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.CompareTag("Ground");
        onGround = true;
    }
}
