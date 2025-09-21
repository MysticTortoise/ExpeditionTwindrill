using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class GrowShrink : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform enemy;
    private float timer;
    public float sizeMin;
    public float sizeMax;
    public float speed = 1;


    void Update()
    {
        timer += Time.deltaTime * speed;
        float size = Mathf.Lerp(sizeMin, sizeMax, Math.Abs(Mathf.Sin(timer)));
        enemy.localScale = new Vector3(size, size, size);
    
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        float spriteSize = GetComponent<CircleCollider2D>().radius;

        Gizmos.DrawWireSphere(transform.position, sizeMin * spriteSize);
        Gizmos.DrawWireSphere(transform.position, sizeMax * spriteSize);
    }
}
