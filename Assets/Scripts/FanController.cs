using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
    public float fanPower;

    private PlaneController gamePlayer;

    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<PlaneController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gamePlayer.TriggerFan(fanPower);
        }
    }
}
