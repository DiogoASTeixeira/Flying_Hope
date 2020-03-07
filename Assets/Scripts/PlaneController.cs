using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float fanSpeed;
    public float verticalAngleMod;
    public float horizontalAngleMod;
    private float angle;
    private Vector3 vectorX;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        vectorX = new Vector3(1, 0, 0);
        rigidBody.AddForce(transform.right * 1, ForceMode2D.Impulse);
        angle = getAngle();
        rigidBody.SetRotation(-angle);
    }

    // Update is called once per frame
    void Update()
    {
        angle = getAngle();
        Debug.Log(angle);
        Debug.Log(Mathf.Sin(angle * Mathf.Deg2Rad));
        rigidBody.SetRotation(angle);
        //rigidBody.velocity += new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad) * horizontalAngleMod,- Mathf.Sin(angle * Mathf.Deg2Rad) * verticalAngleMod);


    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Fan"))
        {
            rigidBody.AddForce(new Vector2(0, 1) * fanSpeed, ForceMode2D.Force);
        }
    }

    private float getAngle()
    {
        Vector3 moveVector = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, 0);
        if (Mathf.Abs(moveVector.x) < 0.1 && Mathf.Abs(moveVector.y) < 0.1)
        {
            return -90;
        }
        return Vector3.SignedAngle(vectorX, moveVector, Vector3.forward);
    }
}
