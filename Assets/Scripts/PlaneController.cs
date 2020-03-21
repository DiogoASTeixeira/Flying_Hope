using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    public RectTransform gameOverPanel;
    public Button restart; 

    private Rigidbody2D rb;
    private float planeAngle;

    private bool hasStarted = false;
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

        restart.onClick.AddListener(restartGame);

        SetAngle();

    }

    private void restartGame()
    {
        Debug.Log("entrei");
        Application.LoadLevel(Application.loadedLevel);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (!gameOver)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if(!hasStarted)
                {
                    rb.isKinematic = false;
                    hasStarted = true;
                }
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            if(hasStarted)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
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
            rb.velocity = new Vector2(0, 0);
            gameOverPanel.gameObject.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            ScoreManager.instance.ChangeScore();
        }
    }

    public void increaseSpeed(float increase)
    {
        speed += increase;
    }
}
