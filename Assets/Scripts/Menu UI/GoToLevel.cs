using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GoToLevel : MonoBehaviour
{
    public Button button;

    public void Start()
    {
        if (SaveGame.levelsBeaten < int.Parse(button.name)-1)
        {
            button.interactable = false;
        }
    }

    public void goToLevel()
    {
        WipeTransition.SceneTransition("Level" + button.name);
    }
}
