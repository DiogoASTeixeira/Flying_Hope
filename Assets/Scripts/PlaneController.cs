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

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector3 vectorX;
    private float planeAngle;
    private float inputTilt;
    private float jumpTimeCounter;
    private float moveInput;
    private float speed = 4;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        vectorX = new Vector3(1, 0, 0);

        SetAngle();
    }

    // Update is called once per frame
    void Update()
    {
        if (onGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector2.up * jumpForce;
                isJumping = true;
                jumpTimeCounter = jumpTime;
            }
        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
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

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        //FlipHorizontal();
        //SetAngle();
        //inputTilt = Input.GetAxis("Horizontal");
        //rb.SetRotation(rb.rotation - inputTilt * tiltPower);
        //AirResistanceForce();

    }

    /*
    private void AirResistanceForce()
    {
        if (transform.position.y > -3.5)
        {
            Vector2 perpendicular = Vector2.Perpendicular(new Vector2(Mathf.Cos(rb.rotation * Mathf.Deg2Rad), Mathf.Sin(rb.rotation * Mathf.Deg2Rad)));
            rb.AddForce(perpendicular * airResistanceForce, ForceMode2D.Force);
        }
    }
    */
    private void FlipHorizontal() => sr.flipY = rb.velocity.x < -0.5f;

    public void TriggerFan(float fanPower)
    {
        rb.AddForce(new Vector2(0, 1) * fanPower, ForceMode2D.Force);
    }

    private void SetAngle()
    {
        Vector3 moveVector = new Vector3(rb.velocity.x, rb.velocity.y, 0);
        if (transform.position.y < -3.7)
        {
            moveVector = vectorX;
            rb.velocity = new Vector2(0f, 0f);
        }
        planeAngle = Vector3.SignedAngle(vectorX, moveVector, Vector3.forward);
        rb.SetRotation(planeAngle);
    }

    /*
    public void LaunchPlane(float force, float angle)
    {
        angle *= Mathf.Deg2Rad;
        planeAngle = angle;
        rb.AddForce(launchPower * force * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)), ForceMode2D.Impulse);
    }
    */

    public void SetKinematic(bool boolean) => rb.isKinematic = boolean;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.CompareTag("Ground");
        onGround = true;
    }
}
