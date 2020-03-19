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
    private float planeAngle;
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetAngle();

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            
        }
    }

    private void FixedUpdate()
    {
        if (!gameOver)
        {
            if (onGround)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // rb.velocity = Vector2.up * jumpForce;
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    isJumping = true;
                    onGround = false;
                    jumpTimeCounter = jumpTime;
                }
            }

            if (Input.GetKey(KeyCode.Space) && isJumping && !onGround)
            {
                if (true || jumpTimeCounter > 0)
                {
                    //rb.velocity = Vector2.up * jumpForce;

                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                    onGround = true;
                }
            }

            rb.velocity = new Vector2(speed, rb.velocity.y);
            SetAngle();
        }
    }

    private void SetAngle()
    {
        Vector3 moveVector = new Vector3(rb.velocity.x, rb.velocity.y, 0);

        planeAngle = Vector3.SignedAngle(Vector2.right, moveVector, Vector3.forward);
        rb.SetRotation(planeAngle);
    }

    public void TriggerFan(float fanPower)
    {
        rb.AddForce(new Vector2(0, 1) * fanPower, ForceMode2D.Force);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Column")){
            gameOver = true;
            onGround = true;
            isJumping = false;
            rb.velocity = new Vector2(0, 0);
            
        }

        Debug.Log(gameOver);
    }
}
