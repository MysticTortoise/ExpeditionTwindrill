using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public void ShowGameOver()
    {
        transform.Find("gameover").gameObject.SetActive(true);
    }

    public void ShowWin()
    {
        transform.Find("youwin").gameObject.SetActive(true);
    }
}
