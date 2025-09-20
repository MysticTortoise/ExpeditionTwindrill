using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
public float masterVolume = 1f;
public float musicVolume = 1f;
public float SFX = 1f;
    public static GlobalSettings Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
