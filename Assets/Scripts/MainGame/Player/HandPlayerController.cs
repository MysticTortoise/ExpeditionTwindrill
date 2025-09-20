using UnityEngine;
using System.Collections.Generic;

public class HandPlayerController : MonoBehaviour
{
    // Properties
    [SerializeField] private float MaxArmDist;

    [SerializeField] private float PullMoveAcceleration;

    // Internal trackers
    // position
    [HideInInspector] public Vector3 goalPosition;
    private Vector3 trueGoal;
    // colliders
    private BoxCollider2D handCollider;
    private List<GrabbableObject> overlappingObjects = new List<GrabbableObject>();

    private GrabbableObject? latchedObject = null;
    private bool movePull = false;

    private bool latched { get { return latchedObject != null; } }
    
    // Relational Objects
    private SubPlayerController sub;
    private Transform chainTransform;

    public void SetSub(SubPlayerController sub) { this.sub = sub; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chainTransform = transform.Find("Chain");
        handCollider = GetComponent<BoxCollider2D>();

    }

    private void UpdateVisuals()
    {
        transform.position = trueGoal;
        chainTransform.position = sub.transform.position + ((transform.position - sub.transform.position) / 2);
        chainTransform.rotation = Quaternion.Euler(0, 0,
            Mathf.Rad2Deg * Mathf.Atan2(transform.position.y - sub.transform.position.y, transform.position.x - sub.transform.position.x) + 90);
        chainTransform.localScale = new Vector3(.5f, Vector3.Distance(transform.position, sub.transform.position), .5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (latched)
        {
            if (movePull)
            {
                sub.AddForce((trueGoal - sub.transform.position).normalized * PullMoveAcceleration * Time.deltaTime);
            }
        } else
        {
            Vector3 offset = (goalPosition - sub.transform.position);
            trueGoal = sub.transform.position + offset.normalized * Mathf.Min(MaxArmDist, offset.magnitude);
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
            }
        }
    }

    public void Release()
    {
        latchedObject = null;
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
