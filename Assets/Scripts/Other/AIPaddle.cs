using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    private float aiSpeed = 8;
    public Transform ball;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ball.position.x > transform.position.x)
        {
            transform.position += Vector3.right * aiSpeed * Time.deltaTime;
        }
        else if (ball.position.x < transform.position.x)
        {
            transform.position += Vector3.left * aiSpeed * Time.deltaTime;
        }

        float ClampX = Mathf.Clamp(transform.position.x, -8.48f, 8.48f);
        transform.position = new Vector3(ClampX, transform.position.y, transform.position.z);
    }
}
