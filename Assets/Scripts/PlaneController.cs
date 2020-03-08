using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float fanSpeed;
    public float verticalAngleMod;
    public float horizontalAngleMod;

    private Rigidbody2D rb;
    private float angle;
    private Vector3 vectorX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vectorX = new Vector3(1, 0, 0);
        //rigidBody.AddForce(transform.right * 1, ForceMode2D.Impulse);
        angle = getAngle();
        rb.SetRotation(-angle);
    }

    // Update is called once per frame
    void Update()
    {
        angle = getAngle();
        // Debug.Log(angle);
        // Debug.Log(Mathf.Sin(angle * Mathf.Deg2Rad));
        rb.SetRotation(angle);
        //rigidBody.velocity += new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad) * horizontalAngleMod,- Mathf.Sin(angle * Mathf.Deg2Rad) * verticalAngleMod);


    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Fan"))
        {
            rb.AddForce(new Vector2(0, 1) * fanSpeed, ForceMode2D.Force);
        }
    }

    private float getAngle()
    {
        Vector3 moveVector = new Vector3(rb.velocity.x, rb.velocity.y, 0);
        if (Mathf.Abs(moveVector.x) < 0.1 && Mathf.Abs(moveVector.y) < 0.1)
        {
            return -90;
        }
        return Vector3.SignedAngle(vectorX, moveVector, Vector3.forward);
    }

    public void LaunchPlane(float force)
    {
        rb.AddForce(2 * force * new Vector2(Mathf.Cos(45 * Mathf.Deg2Rad), Mathf.Sin(45 * Mathf.Deg2Rad)), ForceMode2D.Impulse);
    }

}
