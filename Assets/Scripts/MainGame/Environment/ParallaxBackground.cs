using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private Material material;
    [SerializeField] private new Camera camera;
    [SerializeField] private Vector2 scrollModifier;

    private const float Base43RatioMaxExtents = 13.3382f;
    private const float Base43RatioScale = 6.993493f;
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
        Bounds bounds = MathUtil.OrthographicBounds(camera);
        float biggestSize = Mathf.Max(bounds.extents.x, bounds.extents.y);
        
        
        
        transform.position = bounds.center + new Vector3(0,0,5);
        float desiredSize = (Base43RatioScale / Base43RatioMaxExtents) * biggestSize;
        transform.localScale = new Vector3(desiredSize,desiredSize,1);
        material.SetVector("_UVOffset", camera.transform.position * scrollModifier);
        material.SetFloat("_UVScale", biggestSize / Base43RatioMaxExtents);
    }
}
