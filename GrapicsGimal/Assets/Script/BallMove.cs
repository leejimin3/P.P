using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallMove: MonoBehaviour

{
    public AudioSource Sound;
    private Rigidbody2D ballRd;         

    float speed = 300.0f;

    public void Start()
    {
        ballRd = GetComponent<Rigidbody2D>();
        ballRd.AddForce(new Vector2(speed, speed * 0.7f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Sound.Play();
        if (collision.gameObject.name == "Death")
        {
            Destroy(GameObject.Find("Ball(Clone)"));
            GameObject.Find("Canvas").transform.Find("GameOverPanel").gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}

