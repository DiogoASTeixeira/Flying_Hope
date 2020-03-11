using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float fanSpeed;
    public float airResistanceForce;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector3 vectorX;
    private float planeAngle;
    private float inputTilt;


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
        inputTilt = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        FlipHorizontal();
        SetAngle();
        AirResistanceForce();
    }

    private void AirResistanceForce()
    {
        Vector2 perpendicular = Vector2.Perpendicular(rb.velocity.normalized);
        rb.AddForce(perpendicular * airResistanceForce, ForceMode2D.Force);
    }

    private void FlipHorizontal() => sr.flipY = rb.velocity.x < -0.5f;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Fan"))
        {
            rb.AddForce(new Vector2(0, 1) * fanSpeed, ForceMode2D.Force);
        }
    }

    private void SetAngle()
    {
        Vector3 moveVector = new Vector3(rb.velocity.x, rb.velocity.y, 0);
        if (Mathf.Abs(moveVector.x) < 0.1f && Mathf.Abs(moveVector.y) < 0.1f)
        {
            moveVector = vectorX;
            rb.velocity = new Vector2(0f, 0f);
        }
        planeAngle = Vector3.SignedAngle(vectorX, moveVector, Vector3.forward);
        rb.SetRotation(planeAngle);
    }

    public void LaunchPlane(float force, float angle)
    {
        angle *= Mathf.Deg2Rad;
        planeAngle = angle;
        rb.AddForce(15 * force * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)), ForceMode2D.Impulse);
    }

    public void SetKinematic(bool boolean) => rb.isKinematic = boolean;
}
