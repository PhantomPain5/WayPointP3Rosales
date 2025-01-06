using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    public GameObject[] waypoints;
    int currretWP = 0;
    public float speed = 10.0f;
    public float rotspeed = 10.0f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, waypoints[currretWP].transform.position) > 3)
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
