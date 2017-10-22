using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject player;
    Vector3 lastPlayer;
    Quaternion prevPlayer;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        lastPlayer = player.transform.position;
        prevPlayer = player.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 diff = lastPlayer - player.transform.position;
        Quaternion dif = prevPlayer;
        dif.eulerAngles -= player.transform.rotation.eulerAngles;
        if(diff.magnitude > 0 || dif.eulerAngles.magnitude > 0)
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        else
        {
            Time.timeScale = 0.01f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }

        lastPlayer = player.transform.position;
        prevPlayer = player.transform.rotation;
      

       

	}
}
