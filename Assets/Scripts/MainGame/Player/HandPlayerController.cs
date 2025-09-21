using UnityEngine;
using System.Collections.Generic;

public class HandPlayerController : MonoBehaviour
{

    // Components
    private BoxCollider2D handCollider;
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Properties
    [SerializeField] private float MaxArmDist;

    [SerializeField] private float PullMoveAcceleration;
    [SerializeField] private float HandAccel;

    private Sprite normalSprite;

    // Internal trackers
    // position
    [HideInInspector] public Vector3 goalPosition;
    private Vector3 trueGoal;
    // colliders
    private List<GrabbableObject> overlappingObjects = new List<GrabbableObject>();

    private GrabbableObject? latchedObject = null;
    private bool movePull = false;

    private float shockTimer;

    private bool latched { get { return latchedObject != null; } }
    
    // Relational Objects
    private SubPlayerController sub;
    private DamageHandler damageHandler;
    private Transform chainTransform;
    private SpriteRenderer chainSprite;
    private BoxCollider2D chainCollider;

    private AudioSource chainLoop;
    private AudioSource grabWallSound;
    private AudioSource grabItemSound;

    public void SetSub(SubPlayerController sub) { this.sub = sub; damageHandler = sub.GetComponent<DamageHandler>(); }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chainTransform = transform.Find("Chain");
        chainSprite = chainTransform.GetComponent<SpriteRenderer>();
        chainCollider = chainTransform.GetComponent<BoxCollider2D>();
        chainLoop = chainTransform.GetComponent<AudioSource>();

        grabWallSound = transform.Find("GrabWallSound").GetComponent<AudioSource>();
        grabItemSound = transform.Find("GrabItemSound").GetComponent<AudioSource>();

        handCollider = GetComponent<BoxCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        normalSprite = spriteRenderer.sprite;
    }

    private void UpdateVisuals()
    {
        transform.rotation = Quaternion.Euler(0, 0,
            Mathf.Rad2Deg * Mathf.Atan2(transform.position.y - sub.transform.position.y, transform.position.x - sub.transform.position.x) + 90);
        chainTransform.position = sub.transform.position + ((transform.position - sub.transform.position) / 2);
        chainTransform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);
        chainSprite.size = new Vector2(.02f,Vector3.Distance(transform.position, sub.transform.position) / chainTransform.localScale.y);
        chainCollider.size = new Vector2(.04f, chainSprite.size.y);

        animator.SetBool("Grab", latched);
        animator.SetBool("Shock", shockTimer > 0);
        chainLoop.mute = !latched;
    }

    // Update is called once per frame
    void Update()
    {
        if(shockTimer > 0)
        {
            shockTimer -= Time.deltaTime;
        }
        //Debug.Log(latched);
        if (latched)
        {
            rigidBody.linearVelocity = new Vector3();
            if (movePull)
            {
                sub.AddForce((trueGoal - sub.transform.position).normalized * PullMoveAcceleration * Time.deltaTime);
            }
            else
            {
                GrabbablePickup pickup = latchedObject as GrabbablePickup;
                pickup.AddForce(
                    pickup.PullAcceleration * Time.deltaTime * (sub.transform.position - pickup.transform.position)
                    );
                transform.position = pickup.transform.position;
            }
        } else
        {
            Vector3 offset = (goalPosition - sub.transform.position);
            trueGoal = sub.transform.position + offset.normalized * Mathf.Min(MaxArmDist, offset.magnitude);
            rigidBody.AddForce((trueGoal - transform.position).normalized * HandAccel * Time.deltaTime);
        }
        UpdateVisuals();

    }

    public void Grab()
    {
        foreach(GrabbableObject obj in overlappingObjects)
        {
            if(obj is GrabbableWall wall)
            {
                latchedObject = wall;
                movePull = true;
                grabWallSound.PlayOneShot(grabWallSound.clip);
            }
            if(obj is GrabbablePickup pickup)
            {
                latchedObject = pickup;
                movePull = false;
                grabItemSound.PlayOneShot(grabItemSound.clip);
            }
        }
    }

    public void Release()
    {
        latchedObject = null;
    }

    public void Shock()
    {
        shockTimer = damageHandler.cooldownTime;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GrabbableObject? grabbableObject = collider.gameObject.GetComponent<GrabbableObject>();
        if (grabbableObject != null)
        {
            overlappingObjects.Add(grabbableObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        GrabbableObject? grabbableObject = collider.gameObject.GetComponent<GrabbableObject>();
        if(grabbableObject != null && overlappingObjects.Contains(grabbableObject))
        {
            overlappingObjects.Remove(grabbableObject);
        }
    }

}
