using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float bounceForce;
    private int score = 0;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
    }
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    StartBounce();
        //}
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Paddle"))
        {
            AudioManager.instance.BallBounce();
            StartBounce();
            Score();
        }

        if (other.gameObject.CompareTag("FallCheck"))
        {
            GameManager.instance.Restart();
        }
    }

    void StartBounce()
    {
        Vector2 randomDirection = new Vector2(Random.Range(-1, 1), 1);
        //rb2d.AddForce(randomDirection * bounceForce, ForceMode2D.Impulse );
        rb2d.velocity += randomDirection * bounceForce;
    }

    void Score()
    {
        score++;
        UIManager.Instance.UpdateScore(score);
    }

    
}
