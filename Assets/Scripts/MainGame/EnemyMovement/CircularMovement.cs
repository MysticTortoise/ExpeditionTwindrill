using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CircleMovement : MonoBehaviour
{
public float timeScale;
public float radius;
public Rigidbody2D rb;
private float timer;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime/timeScale;
        float xValue = radius*Mathf.Cos(timer)/timeScale;
        
        float yValue = radius*Mathf.Sin(timer)/timeScale;
        if (timer <= Math.PI/2)
        {
            rb.linearVelocityX = xValue;
            rb.linearVelocityY = yValue;
        }
        else if (timer <= Math.PI)
        {
            rb.linearVelocityX = xValue;
            rb.linearVelocityY = yValue;
        }
        else if (timer <= Math.PI*3/4)
        {
            rb.linearVelocityX = xValue;
            rb.linearVelocityY = yValue;
        }
        else if (timer <= Math.PI*2)
        {
            rb.linearVelocityX = xValue;
            rb.linearVelocityY = yValue;
        }
        else
        {
            timer = 0;
        }
    }   
    
}