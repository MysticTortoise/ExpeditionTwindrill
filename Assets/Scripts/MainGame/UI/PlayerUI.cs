using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private DamageHandler damageHandler;
    private int maxHealth;

    private Image healthBar;

    private void Start()
    {
        healthBar = transform.Find("Health").Find("Bar").GetComponent<Image>();

        damageHandler = transform.parent.Find("Sub").GetComponent<DamageHandler>();
        maxHealth = damageHandler.health;
    }

    public void ShowGameOver()
    {
        transform.Find("gameover").gameObject.SetActive(true);
    }

    public void ShowWin()
    {
        transform.Find("youwin").gameObject.SetActive(true);
    }

    private void Update()
    {
        healthBar.fillAmount = damageHandler.health / (float)maxHealth;
    }
}
