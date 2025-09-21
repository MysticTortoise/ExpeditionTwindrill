using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{


    public void NextLevel()
    {
        string curLevelName = SceneManager.GetActiveScene().name;
        int levelNumber = int.Parse(curLevelName.Replace("Level", ""));
        levelNumber++;
        int nextLevelIndex = SceneUtility.GetBuildIndexByScenePath("Assets/Scenes/Levels/Level" + levelNumber.ToString() + ".unity");
        if (nextLevelIndex != -1)
        {
            SceneManager.LoadScene(nextLevelIndex);
            return;
        }
        MusicHandler.StopMusic();
        MainMenu();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        MusicHandler.StopMusic();
    }
}
