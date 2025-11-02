using UnityEngine;

public class SaveGame
{
    public static int levelsBeaten;
    public static void Save()
    {
        PlayerPrefs.SetInt("levels", levelsBeaten);
        PlayerPrefs.Save();
    }

    public static void Load()
    {
        levelsBeaten = PlayerPrefs.GetInt("levels");
    }
}
