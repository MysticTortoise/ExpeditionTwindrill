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
    [Range(0,Mathf.PI*2)] public float offset;
    private Vector3 originPoint;

    private void Start()
    {
        originPoint = transform.position;
        timer = offset;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime / timeScale;
        transform.position = originPoint + new Vector3(
            Mathf.Cos(timer) * radius, Mathf.Sin(timer) * radius
            );
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(Mathf.Cos(timer), Mathf.Sin(timer)));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(Mathf.Cos(offset), Mathf.Sin(offset)) * radius);
    }

}