using System;
using System.Linq;
using UnityEngine;


[Serializable]
struct SpriteDir
{
    public Sprite[] sprites;
    public bool flipX;
}

public class SubPlayerController : MonoBehaviour
{
    [SerializeField] private SpriteDir[] spriteDirs;
    [SerializeField] private float animateTime;

    private const float RAD_TO_REV = 0.159155f;
    private const float REV_TO_RAD = 6.283185f;

    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;

    private float animTimer;
    private int animFrame;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public void AddForce(Vector3 force)
    {
        rigidBody.AddForce(force);
    }

    private void Update()
    {
        animTimer += Time.deltaTime;
        if(animTimer >= animateTime)
        {
            animTimer = 0;
            animFrame = (animFrame + 1) % spriteDirs[0].sprites.Length;
        }

        float myAngle = (Mathf.Atan2(rigidBody.linearVelocityY, rigidBody.linearVelocityX) + Mathf.PI * 2) % (Mathf.PI * 2);

        myAngle *= RAD_TO_REV;
        myAngle *= spriteDirs.Length;
        int index = (int)Mathf.Round(myAngle);
        index %= spriteDirs.Length;
        
        spriteRenderer.sprite = spriteDirs[index].sprites[animFrame];
        spriteRenderer.flipX = spriteDirs[index].flipX;
    }


#if UNITY_EDITOR

    void OnDrawGizmos()
    {
        int quadrants = 8;
        if (rigidBody == null)
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }

        float myAngle = Mathf.Atan2(rigidBody.linearVelocityY, rigidBody.linearVelocityX);

        Gizmos.color = new Color(0.75f, 0.0f, 0.0f, 0.75f);
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(Mathf.Cos(myAngle), Mathf.Sin(myAngle)));

        myAngle *= RAD_TO_REV;
        myAngle *= spriteDirs.Length;
        int index = (int)Mathf.Round(myAngle);

        myAngle = index * (360 / spriteDirs.Length) * Mathf.Deg2Rad;

        Gizmos.color = new Color(0.0f, 0.0f, 0.75f, 0.75f);
        Gizmos.DrawLine(transform.position,  transform.position + new Vector3(Mathf.Cos(myAngle), Mathf.Sin(myAngle)));

        Gizmos.color = new Color(0.0f, 0.75f, 0.0f, 0.75f);
        
       

        for(int i = 0; i < quadrants; i++)
        {
            float beginAngle = Mathf.Deg2Rad * (i * (360f / quadrants) + .5f * (360f / quadrants));
            Gizmos.DrawLine(transform.position,
                transform.position + new Vector3(Mathf.Cos(beginAngle), Mathf.Sin(beginAngle))
                );
        }
    }
#endif
}
