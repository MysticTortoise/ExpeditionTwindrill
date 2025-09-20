using System.Collections;
using UnityEngine;

public class updownmovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private float timer;
    public float velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer <= 5)
        {
            rb.linearVelocityY = velocity;
        }
        if (timer > 5 && timer <= 10)
        {
            rb.linearVelocityY = -velocity;
        }
        if (timer > 10)
        {
            timer = 0;
        }
        Debug.Log(timer);
    }
    
}
