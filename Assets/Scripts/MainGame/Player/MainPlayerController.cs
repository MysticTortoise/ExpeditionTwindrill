using UnityEngine;
using UnityEngine.InputSystem;

public class MainPlayerController : MonoBehaviour
{
    private Camera playerCamera;
    private HandPlayerController hand;
    private SubPlayerController sub;

    private bool gameOver = false;


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
        if (gameOver)
        {
            return;
        }
        hand.goalPosition = playerCamera.ScreenToWorldPoint((Vector3)mouseScreenPos + new Vector3(0,0,5));

        playerCamera.transform.position = (Vector3)(Vector2)sub.transform.position + new Vector3(0, 0, playerCamera.transform.position.z);
    }

    public void CursorUpdate(InputAction.CallbackContext context)
    {
        Vector2 val = context.ReadValue<Vector2>();
        if(val.y != 0 && val.x != 0)
        {
            mouseScreenPos = val;
        }
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

    public void GameOver()
    {
        Debug.Log("UH OH GAME OVER SAD");
        Destroy(sub.gameObject);
        Destroy(hand.gameObject);
        FindAnyObjectByType<PlayerUI>().ShowGameOver();

        gameOver = true;
    }

    public void Victory()
    {
        GetComponent<PlayerInput>().enabled = false;
        GetComponent<DamageHandler>().invincible = true;
    }
}
