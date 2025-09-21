using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private Material material;
    [SerializeField] private new Camera camera;
    [SerializeField] private Vector2 scrollModifier;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material = GetComponent<Renderer>().material;
        if(camera == null)
        {
            camera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = camera.transform.position + new Vector3(0,0,5);
        material.SetVector("_UVOffset", camera.transform.position * scrollModifier);
    }
}
