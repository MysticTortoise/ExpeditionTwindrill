using UnityEngine;

public class SubPlayerController : MonoBehaviour
{
    [SerializeField] private float MaxSpeed;

    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void AddForce(Vector3 force)
    {
        rigidBody.AddForce(force);
        if(rigidBody.linearVelocity.magnitude > MaxSpeed)
        {
            rigidBody.linearVelocity = rigidBody.linearVelocity.normalized * MaxSpeed;
        }
    }
}
