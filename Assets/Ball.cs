using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float bounceForce;
    private int playerscore = 0;
    private int aiScore = 0;
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
        if (other.gameObject.CompareTag("Paddle"))
        {
            AudioManager.instance.BallBounce();
            StartBounce();
            playerscore++;
            PlayerScore();

        }

        if (other.gameObject.CompareTag("AIPaddle"))
        {
            AudioManager.instance.BallBounce();
            //StartBounce();
            aiScore++;
            AIScore();

        }



        if (other.gameObject.CompareTag("FallCheck"))
        {
            UIManager.Instance.LoosePanel();
            Time.timeScale = 0f;
            //GameManager.instance.Restart();
        }

        if (other.gameObject.CompareTag("PlayerSideFallCheck"))
        {
            UIManager.Instance.LoosePanel();
            Time.timeScale = 0f;
            //GameManager.instance.Restart();
        }

        if (other.gameObject.CompareTag("AISideFallCheck"))
        {
            UIManager.Instance.WinPanel();
            //GameManager.instance.Restart();
            Time.timeScale = 0f;
        }
    }

    void StartBounce()
    {
        Vector2 randomDirection = new Vector2(Random.Range(-1, 1), 1);
        //rb2d.AddForce(randomDirection * bounceForce, ForceMode2D.Impulse );
        rb2d.velocity += randomDirection * bounceForce;
    }

    void PlayerScore()
    {

        UIManager.Instance.PlayerScoreUpdate(playerscore);
    }

    void AIScore()
    {

        UIManager.Instance.AIScoreUpdate(aiScore);
    }
}
