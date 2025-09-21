using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private MainPlayerController mainPlayerController;
    private DamageHandler damageHandler;
    private int maxHealth;

    private Image healthBar;

    private void Start()
    {
        healthBar = transform.Find("Health").Find("Bar").GetComponent<Image>();

        damageHandler = transform.parent.Find("Sub").GetComponent<DamageHandler>();
        mainPlayerController = damageHandler.transform.parent.GetComponent<MainPlayerController>();
        maxHealth = damageHandler.health;
    }

    public void ShowGameOver()
    {
        transform.Find("gameover").gameObject.SetActive(true);
    }

    public void ShowWin()
    {
        if(damageHandler.health != maxHealth)
        {
            transform.Find("youwin").Find("Perfect").gameObject.SetActive(false);
        }
        else
        {
            transform.Find("youwin").Find("Win").gameObject.SetActive(false);
        }
        transform.Find("youwin").gameObject.SetActive(true);
        mainPlayerController.Victory();
    }

    private void Update()
    {
        healthBar.fillAmount = damageHandler.health / (float)maxHealth;
    }
}
