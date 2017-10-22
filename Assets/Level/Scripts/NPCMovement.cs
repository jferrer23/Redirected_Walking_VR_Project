using UnityEngine;
using System.Collections;

public class NPCMovement : MonoBehaviour {
    public Transform[] pathpoints;
    Vector3 currentWaypoint;
    private int ii = 0;

    // Use this for initialization
    void Start () {
        currentWaypoint = pathpoints[1].position;
        

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, currentWaypoint, 0.01f);
        if ((transform.position - pathpoints[1].position).magnitude < 1f)
        {
            currentWaypoint = pathpoints[2].position;
        }
        else if ((transform.position - pathpoints[2].position).magnitude < 1f)
        {
            currentWaypoint = pathpoints[3].position;
        }
        else if ((transform.position - pathpoints[3].position).magnitude < 1f)
        {
            currentWaypoint = pathpoints[4].position;
        }
        
    }
}
