using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject[] spawnPoint;
    int spawnPosition = 0;

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () 
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            transform.position = spawnPoint[0].transform.position; 
        };
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            transform.position = spawnPoint[1].transform.position;
        };
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            transform.position = spawnPoint[2].transform.position;
        };
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            transform.position = spawnPoint[3].transform.position;
        };
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            transform.position = spawnPoint[4].transform.position;
        };
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            transform.position = spawnPoint[5].transform.position;
        };

        if (OVRInput.Get(OVRInput.Button.DpadRight))
        {
            spawnPosition += 1;
            if (spawnPosition > 5) spawnPosition = 0;
            transform.position = spawnPoint[spawnPosition].transform.position;
        }

        if (OVRInput.Get(OVRInput.Button.DpadLeft))
        {
            spawnPosition -= 1;
            if (spawnPosition < 0) spawnPosition = 5;
            transform.position = spawnPoint[spawnPosition].transform.position;
        }
	}
}


// OVRInput.Get(OVRInput.Button.SecondaryShoulder)
// OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger)
// OVRInput.Get(OVRInput.Button.DpadLeft)
// OVRInput.Get(OVRInput.Button.DpadRight)