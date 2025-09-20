using UnityEngine;

public class GrabbablePickup : GrabbableObject
{
    public float PullAcceleration;

    private Rigidbody2D rigidBody;
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void AddForce(Vector2 force)
    {
        rigidBody.AddForce(force);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("PlayerPickup"))
        {
            Pickup();
        }
    }

    public virtual void Pickup()
    {
        Destroy(gameObject);
    }
}
