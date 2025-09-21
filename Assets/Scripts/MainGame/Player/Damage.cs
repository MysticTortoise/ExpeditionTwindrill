using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class damage : MonoBehaviour
{
    [SerializeField] private float damageForce;

    public int health = 10;
    public Collider2D collider;
    public SceneManager gameOver;
    private float cooldownTimer;
    public float cooldownTime = 2f;
    private bool cooldownActive = false;
    private float timer;
    private SpriteRenderer spriteRenderer;
    private SubPlayerController sub;

    private void Start()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        sub = GetComponent<SubPlayerController>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage(collision.contacts[0].point);

        
    }

    public void TakeDamage(Vector2 hitPoint)
    {
        if (!cooldownActive)
        {
            health--;
            cooldownActive = true;
            Debug.Log(health);
            if (health == 0)
            {
                SceneManager.LoadScene("GameOver");
            }

            Vector2 dir = hitPoint - (Vector2)transform.position;
            dir.Normalize();
            dir *= -damageForce;
            sub.AddForce(dir);
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
        spriteRenderer.enabled = !cooldownActive || 
            (cooldownTimer % 0.5f <= 0.25f);
    }

}
