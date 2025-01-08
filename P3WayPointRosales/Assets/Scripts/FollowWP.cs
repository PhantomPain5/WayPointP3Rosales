using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    public GameObject[] waypoints;
    int currretWP = 0;

    public float speed = 10.0f;
    public float rotspeed = 10.0f;

    GameObject tracker;


    void Start()
    {
        tracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        DestroyImmediate(tracker.GetComponent<Collider>());
        tracker.transform.position = this.transform.position;
        tracker.transform.rotation = this.transform.rotation;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, waypoints[currretWP].transform.position) < 10)
            currretWP++;

        if (currretWP >= waypoints.Length)
            currretWP = 0;

        this.transform.LookAt(waypoints[currretWP].transform);
        this.transform.Translate(0, 0, speed * Time.deltaTime);

        Quaternion lookatWP = Quaternion.LookRotation(waypoints[currretWP].transform.position - this.transform.position);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWP, Time.deltaTime);

        this.transform.Translate(0, 0, speed * Time.deltaTime);

    }


}
