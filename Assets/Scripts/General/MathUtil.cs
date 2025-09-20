using UnityEngine;

public class MathUtil
{
    public static float Damp(float a, float b, float lambda, float dt)
    {
        return Mathf.Lerp(a, b, 1 - Mathf.Exp(-lambda * dt));
    }

    public static float Triangle(float x)
    {
        return 2 * (0.5f - Mathf.Abs(x % 1 - 0.5f));
    }
}