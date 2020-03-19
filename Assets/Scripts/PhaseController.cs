using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseController : MonoBehaviour
{
    private PlaneController gamePlayer;

    public float speedIncrease;
    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<PlaneController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gamePlayer.increaseSpeed(speedIncrease);
        }
    }
}
