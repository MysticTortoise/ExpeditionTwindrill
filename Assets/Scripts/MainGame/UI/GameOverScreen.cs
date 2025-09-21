using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void Retry()
    {
        WipeTransition.SceneTransition(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        WipeTransition.SceneTransition("MainMenu");
        MusicHandler.StopMusic();
    }
}
