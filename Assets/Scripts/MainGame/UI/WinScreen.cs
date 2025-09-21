using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void NextLevel()
    {
        string curLevelName = SceneManager.GetActiveScene().name;
        for(int i = 0; i < LevelOrder.levels.Length-1; i++)
        {
            if (LevelOrder.levels[i] == curLevelName)
            {
                SceneManager.LoadScene(LevelOrder.levels[i+1]);
                return;
            }
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
