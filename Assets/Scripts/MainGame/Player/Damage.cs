using UnityEngine;
using UnityEngine.SceneManagement;
public class damage : MonoBehaviour
{
    public int health = 10;
    public PolygonCollider2D collider;
    public SceneManager gameOver;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        Debug.Log(health);
        if (health == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
