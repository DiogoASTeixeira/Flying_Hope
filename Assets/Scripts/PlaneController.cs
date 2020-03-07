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

    private Vector3 origVectorPosition;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        origVectorPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        angle = rigidBody.transform.rotation.z;
        rigidBody.velocity = new Vector2(rigidBody.velocity.x + Mathf.Cos(angle) * horizontalAngleMod, rigidBody.velocity.y + Mathf.Sin(angle) * verticalAngleMod);

        Vector3 moveDirection = transform.position - origVectorPosition;

        if (moveDirection != Vector3.zero)
        {
            Vector3 lookAtPoint = gameObject.transform.position + moveDirection;
            transform.LookAt(lookAtPoint, Vector2.up);  //assuming y-axis is up in your game

        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Fan")
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y + fanSpeed);
        }
    }


}
