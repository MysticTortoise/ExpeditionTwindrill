using UnityEngine;

public class HandOuchy : MonoBehaviour
{
    private damage damageHandler;

    private void Start()
    {
        damageHandler = FindObjectsByType<damage>(FindObjectsSortMode.None)[0];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<DontTouch>() != null)
        {
            damageHandler.TakeDamage(transform.position);
        }
    }
}
