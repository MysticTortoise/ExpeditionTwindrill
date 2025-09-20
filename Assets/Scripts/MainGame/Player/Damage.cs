using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class damage : MonoBehaviour
{
    public int health = 10;
    public PolygonCollider2D collider;
    public SceneManager gameOver;
    public float cooldownTimer;
    public float cooldownScale = 2f;
    private bool cooldownActive = false;
    private float timer;



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!cooldownActive)
        {
            health--;
            cooldownTimer = cooldownScale;
            cooldownActive = true;
            Debug.Log(health);
            if (health == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    void Update()
    {
        if (cooldownActive)
        {

            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                cooldownActive = false;
            }
        }
    }

}
