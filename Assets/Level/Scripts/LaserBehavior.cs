using UnityEngine;
using System.Collections;

public class LaserBehavior : MonoBehaviour {
    public GameObject[] lasers;
    private bool mode;
    private int ii;

    // Use this for initialization
    void Start () {
        mode = true;
        ii = 1;
	}
	
	// Update is called once per frame
	void Update () {
        ii++;
        lasers[0].SetActive(mode);
        lasers[1].SetActive(mode);
        lasers[2].SetActive(mode);
        lasers[3].SetActive(mode);
        lasers[4].SetActive(mode);
        lasers[5].SetActive(mode);

        if (ii > 500)
        {
            mode = !mode;
            ii = 0;
        }
	}
}
