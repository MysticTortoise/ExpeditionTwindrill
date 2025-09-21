using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DamageHandler : MonoBehaviour
{
    [SerializeField] private float damageForce;

    public int health = 10;
    public Collider2D collider;
    public SceneManager gameOver;
    private float cooldownTimer;
    public float cooldownTime = 2f;
    private bool cooldownActive { get { return cooldownTimer > 0; } }
    private SpriteRenderer spriteRenderer;
    private SubPlayerController sub;

    private Animator animator;

    private void Start()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        sub = GetComponent<SubPlayerController>();
        animator = GetComponent<Animator>();
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
            cooldownTimer = cooldownTime;
            Debug.Log(health);
            if (health == 0)
            {
                FindAnyObjectByType<MainPlayerController>().GameOver();
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
        }
        animator.SetBool("Damaged", cooldownActive);
        
    }

}
