using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float loopSpeed;
    public float loopHeight;

    private float origY;
    // Start is called before the first frame update
    void Start()
    {
        origY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        float newY = Mathf.Sin(Time.time * loopSpeed);
        transform.position = new Vector3(position.x, origY + newY * loopHeight, position.z);
    }
}
