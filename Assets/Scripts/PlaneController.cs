using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float fanSpeed;
    public float verticalAngleMod;
    public float horizontalAngleMod;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float angle;
    private Vector3 vectorX;

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
    }

    private void FixedUpdate()
    {
        FlipHorizontal();
        SetAngle();
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
        rb.SetRotation(Vector3.SignedAngle(vectorX, moveVector, Vector3.forward));
        Debug.Log(Vector3.SignedAngle(vectorX, moveVector, Vector3.forward));
    }

    public void LaunchPlane(float force, float angle)
    {
        angle *= Mathf.Deg2Rad;
        rb.AddForce(15 * force * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)), ForceMode2D.Impulse);
    }

    public void SetKinematic(bool boolean) => rb.isKinematic = boolean;
}
