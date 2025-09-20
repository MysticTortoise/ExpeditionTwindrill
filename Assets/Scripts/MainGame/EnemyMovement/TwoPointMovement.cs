using System.Collections;
using UnityEngine;

public class TwoPointMovement : MonoBehaviour
{
    private float timer;
    [SerializeField] private float timeScale = 1;
    private Vector3 posA;
    [SerializeField] private Vector3 posB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posA = transform.position;
        posB += posA;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime / timeScale;
        transform.position = Vector3.Lerp(posA, posB, MathUtil.Triangle(timer));
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
