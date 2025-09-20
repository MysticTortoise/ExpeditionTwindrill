using UnityEngine;

public class StoreCollectible : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static int collectibles = 0;

    public static void addCollectible()
    {
        collectibles++;
    }
    public static void getcollectibleCount()
    {
        Debug.Log(collectibles);
    }
}
