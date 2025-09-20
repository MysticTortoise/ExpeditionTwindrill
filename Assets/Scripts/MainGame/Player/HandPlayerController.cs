using UnityEngine;

public class HandPlayerController : MonoBehaviour
{

    [HideInInspector] public Vector3 goalPosition;

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
        transform.position = goalPosition;

        chainTransform.position = sub.transform.position + ((goalPosition - sub.transform.position) / 2);
        chainTransform.rotation = Quaternion.Euler(0,0, 
            Mathf.Rad2Deg * Mathf.Atan2(goalPosition.y - sub.transform.position.y, goalPosition.x - sub.transform.position.x) + 90);
        Debug.Log(Vector3.Distance(goalPosition, sub.transform.position));
        chainTransform.localScale = new Vector3(.5f, Vector3.Distance(goalPosition, sub.transform.position),.5f);
    }

}
