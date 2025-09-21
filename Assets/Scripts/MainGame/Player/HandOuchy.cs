using UnityEngine;

public class HandOuchy : MonoBehaviour
{
    private DamageHandler damageHandler;
    private HandPlayerController hand;

    private void Start()
    {
        damageHandler = FindObjectsByType<DamageHandler>(FindObjectsSortMode.None)[0];
        hand = FindAnyObjectByType<HandPlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<DontTouch>() != null)
        {
            damageHandler.TakeDamage(transform.position, 0.5f);
            hand.Shock();
        }
    }
}
