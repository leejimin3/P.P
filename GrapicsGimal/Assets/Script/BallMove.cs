using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallMove: MonoBehaviour

{

    private Rigidbody2D ballRd;         

    float speed = 1000.0f;

    public void Start()
    {
        ballRd = GetComponent<Rigidbody2D>();
        ballRd.AddForce(new Vector2(speed, speed * 0.7f));
    }
}

