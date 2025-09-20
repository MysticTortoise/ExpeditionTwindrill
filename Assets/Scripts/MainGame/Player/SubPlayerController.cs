using UnityEngine;

public class SubPlayerController : MonoBehaviour
{

    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void AddForce(Vector3 force)
    {
        rigidBody.AddForce(force);
    }
}
