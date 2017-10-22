using UnityEngine;
using System.Collections;

public class Surveillance : MonoBehaviour {
    public bool switchTime;
    // Use this for initialization
    void Start() {
        switchTime = true;
    }

    // Update is called once per frame
    void Update() {
        if (transform.eulerAngles.y > 90)
            switchTime = !switchTime;





        if (switchTime == true)
            transform.Rotate(Vector3.up * Time.deltaTime * 30);
        
        if(switchTime == false) 
            transform.Rotate(Vector3.down * Time.deltaTime * 30);


        ;
    }
}
