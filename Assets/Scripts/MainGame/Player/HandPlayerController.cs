using UnityEngine;

public class HandPlayerController : MonoBehaviour
{

    [SerializeField] private float MaxArmDist;

    [HideInInspector] public Vector3 goalPosition;
    private Vector3 trueGoal;

    private SubPlayerController sub;
    private Transform chainTransform;


    public void SetSub(SubPlayerController sub) { this.sub = sub; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chainTransform = transform.Find("Chain");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = (goalPosition - sub.transform.position);
        trueGoal = sub.transform.position + offset.normalized * Mathf.Min(MaxArmDist, offset.magnitude);

        transform.position = trueGoal;

        // Update Chain visuals
        chainTransform.position = sub.transform.position + ((transform.position - sub.transform.position) / 2);
        chainTransform.rotation = Quaternion.Euler(0,0, 
            Mathf.Rad2Deg * Mathf.Atan2(transform.position.y - sub.transform.position.y, transform.position.x - sub.transform.position.x) + 90);
        chainTransform.localScale = new Vector3(.5f, Vector3.Distance(transform.position, sub.transform.position),.5f);
    }

}
