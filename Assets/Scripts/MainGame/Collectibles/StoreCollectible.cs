using UnityEngine;

public class StoreCollectible : MonoBehaviour
{
    public static StoreCollectible instance;

    private int collectibles = 0;
    private int collectibleCount;

    private void Start()
    {
        collectibles = 0;
        if(instance != null)
        {
            Destroy(instance.gameObject);
        }
        instance = this;

        collectibleCount = FindObjectsByType<GrabbableCollectible>(FindObjectsSortMode.None).Length;
    }

    public void AddCollectible()
    {
        collectibles++;
        GetCollectibleCount();
        if(collectibles >= collectibleCount)
        {
            Win();
        }
    }
    public void GetCollectibleCount()
    {
        Debug.Log(collectibles);
    }

    private void Win()
    {
        FindAnyObjectByType<PlayerUI>().ShowWin();
        Debug.Log("YOU WIN!!! :D");
    }
}
