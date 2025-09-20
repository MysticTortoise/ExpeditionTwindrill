using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class TwoPointMovement : MonoBehaviour
{
    private float timer;
    [SerializeField] private float timeScale = 1;
    private Vector3 posA;
    [SerializeField] private Vector3 posB;
    private SpriteRenderer renderer;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        posA = transform.position;
        posB += posA;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime / timeScale;
        float alpha = MathUtil.Triangle(timer);
        transform.position = Vector3.Lerp(posA, posB, alpha);
        if (alpha >= .95)
        {
            renderer.flipX = true;
        }
        if (alpha <= .05)
        {
            renderer.flipX = false;
        }
        
    }
#if UNITY_EDITOR

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0.75f, 0.0f, 0.0f, 0.75f);
        Vector3 posBmodified = posB;
        if (!Application.isPlaying)
        {
            posA = transform.position;
            posBmodified = posA + posB;
        }



        // Convert the local coordinate values into world
        // coordinates for the matrix transformation.
        Gizmos.DrawLine(posA, posBmodified);
    }
#endif

}
