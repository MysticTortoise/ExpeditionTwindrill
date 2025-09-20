using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{

  public Rigidbody2D rb;
    private float timer;
    public float velocity;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer <= 2.5)
        {
            rb.linearVelocityX = velocity;
            rb.linearVelocityY = velocity;
        }

        if (timer > 2.5 && timer <= 5 )
        {
            rb.linearVelocityX = -velocity;
            rb.linearVelocityY = velocity;
        }

        if (timer > 5 && timer <= 7.5)
        {
            rb.linearVelocityX = -velocity;
            rb.linearVelocityY = -velocity;
        }
        if (timer > 7.5 && timer <= 10)
        {
            rb.linearVelocityX =  velocity;
            rb.linearVelocityY = -velocity;
        }
        if (timer > 10)
        {
            timer = 0;
        }
        Debug.Log(timer);
    }
    
}