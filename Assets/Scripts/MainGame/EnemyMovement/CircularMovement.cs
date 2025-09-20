using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CircleMovement : MonoBehaviour
{
    private float timer = 0;
    public float timeScale;
    public float radius;
    private Vector3 originPoint;

    private void Start()
    {
        originPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime / timeScale;
        transform.position = originPoint + new Vector3(
            Mathf.Cos(timer) * radius, Mathf.Sin(timer) * radius
            );
    }   
    
}