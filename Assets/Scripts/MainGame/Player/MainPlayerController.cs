using UnityEngine;
using UnityEngine.InputSystem;

public class MainPlayerController : MonoBehaviour
{
    private Camera playerCamera;
    private HandPlayerController hand;
    private SubPlayerController sub;

    private Vector2 mouseGoalPos;
    private Vector2 mouseScreenPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCamera = transform.Find("Camera").GetComponent<Camera>();
        hand = transform.Find("Hand").GetComponent<HandPlayerController>();
        sub = transform.Find("Sub").GetComponent<SubPlayerController>();

        hand.SetSub(sub);
    }

    // Update is called once per frame
    void Update()
    {
        hand.goalPosition = playerCamera.ScreenToWorldPoint((Vector3)mouseScreenPos + new Vector3(0,0,5));
    }

    public void CursorUpdate(InputAction.CallbackContext context)
    {
        mouseScreenPos = context.ReadValue<Vector2>();
    }

    public void GrabInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            hand.Grab();
        } else if (context.canceled)
        {
            hand.Release();
        }
    }
}
