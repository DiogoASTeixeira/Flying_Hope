using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherController : MonoBehaviour
{
    public float jumpForce;

    private Rigidbody2D rb;
    private bool isOnGround;
    private bool willJump;

    // Start is called before the first frame update
    void Start()
    {
        willJump = false;
        isOnGround = false;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(willJump)
        {
            Jump();
            isOnGround = false;
            willJump = false;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");

        isOnGround = true;

        if(collision.gameObject.CompareTag("Ground") && isOnGround)
        {
            isOnGround = false;
            willJump = true;
        }
    }

    private void Jump()
    {
        Debug.Log("Jump");

        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
    }
}
