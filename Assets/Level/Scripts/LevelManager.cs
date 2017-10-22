using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

    public GameObject enemyPrefab;
    public int enemy = 3;    
	// Use this for initialization
	void Start () {
        List<GameObject[]> roomSelect = new List<GameObject[]>();
        roomSelect.Add(GameObject.FindGameObjectsWithTag("Room1"));
        roomSelect.Add(GameObject.FindGameObjectsWithTag("Room2"));
        roomSelect.Add(GameObject.FindGameObjectsWithTag("Room3"));
        roomSelect.Add(GameObject.FindGameObjectsWithTag("Room4"));

        for(int i = 0; i < enemy; i++)
        {
            int room = Random.Range(0, roomSelect.Count);
            GameObject[] tiles = roomSelect[room];
            int tile = Random.Range(0, tiles.Length);
            Vector3 pos = tiles[tile].transform.position + new Vector3(0, 0.5f, 0);
            Quaternion rot = Quaternion.Euler(0, Random.Range(0, 360), 0);
            Instantiate(enemyPrefab, pos, rot);
            roomSelect.RemoveAt(room);
        }


        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
