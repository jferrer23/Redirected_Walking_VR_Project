using UnityEngine;
using System.Collections;

public class SlidingMovement : MonoBehaviour {
    public Transform openPos;
    public Transform closedPos;
    Vector3 currentWayPoint;
    private bool mode;
    private int ii;
	// Use this for initialization
	void Start () {
        currentWayPoint = closedPos.position;
        mode = true;
        ii = 1;
    }

    // Update is called once per frame
    void Update () {
        if(mode == true)
        {
            transform.position = Vector3.Lerp(transform.position, currentWayPoint, 0.1f);
        }
        if ((transform.position - closedPos.position).magnitude < 0.1f)
        {
            currentWayPoint = openPos.position;
            mode = false;
            ii++;
        }
        else if((transform.position - openPos.position).magnitude < 0.1f)
        {
            currentWayPoint = closedPos.position;
            mode = false;
            ii++;
        }

        if(ii > 700)
        {
            mode = true;
            ii = 0;
        }


    }
}
