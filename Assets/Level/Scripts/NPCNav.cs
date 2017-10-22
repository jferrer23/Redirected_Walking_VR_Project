using UnityEngine;
using System.Collections;

public class NPCNav : MonoBehaviour {
    NavMeshAgent agent;
    public GameObject[] targets;
    Vector3 currentWaypoint;
    public Transform player;
    Animator anim;
    private bool firstpatrol;
    private int idlestate;
    private bool attack;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        targets = GameObject.FindGameObjectsWithTag("WayPoint");
        currentWaypoint = targets[Random.Range(0, targets.Length)].transform.position;
        agent.SetDestination(currentWaypoint);
        anim.SetBool("Run", false);
        anim.SetBool("Attack", false);
        anim.SetBool("Patrol", false);
        firstpatrol = false;
        attack = false;
        idlestate = 0;
       
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            currentWaypoint = player.position;
            attack = true;
            agent.SetDestination(currentWaypoint);
        }
    }

    // Update is called once per frame
    void Update () {

        if(currentWaypoint == player.position)
        {
            attack = true;
        }
        else
        {
            attack = false;
        }

        if((transform.position - currentWaypoint).magnitude > 4f)
        {
            anim.SetBool("Run", true);
            agent.SetDestination(currentWaypoint);

        }
        else if((transform.position - currentWaypoint).magnitude > 1f)
        {
            anim.SetBool("Run", false);
            agent.SetDestination(currentWaypoint);
        }
        else
        {
            if (attack == true)
            {
                anim.SetBool("Attack", true);
            }
            else
            {
                anim.SetBool("Patrol", true);
            }
        }
     
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Attacking") == true || stateInfo.IsName("Looking") == true)
        {
            idlestate++;
        }


        if (idlestate > 200)
        {
            if(stateInfo.IsName("Looking") == true && idlestate > 500)
            {
                anim.SetBool("Run", false);
                anim.SetBool("Attack", false);
                anim.SetBool("Patrol", false);
                if (firstpatrol == false)
                {
                    currentWaypoint = player.position;
                    firstpatrol = true;
                }
                else
                {
                    currentWaypoint = targets[Random.Range(0, targets.Length)].transform.position;
                }
                idlestate = 0;
            }
            else
            {
                anim.SetBool("Run", false);
                anim.SetBool("Attack", false);
                anim.SetBool("Patrol", false);
                if (firstpatrol == false)
                {
                    currentWaypoint = player.position;
                    firstpatrol = true;
                }
                else
                {
                    currentWaypoint = targets[Random.Range(0, targets.Length)].transform.position;
                }
                idlestate = 0;
            }
           
        }



    }
}
