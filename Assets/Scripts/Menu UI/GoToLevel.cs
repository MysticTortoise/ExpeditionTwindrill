using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GoToLevel : MonoBehaviour
{
    public Button button;
    
    public void goToLevel()
    {
        SceneManager.LoadScene("Level" + button.name);
    }
}
