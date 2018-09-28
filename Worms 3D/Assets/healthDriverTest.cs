using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Worked on by:
 * Ryan Madigan
 * Dean Kennelly
 * Evan Barry
 * Jack Gammon*/

public class healthDriverTest : MonoBehaviour {
    Health myHealth;
	// Use this for initialization
	void Start () {
        myHealth = GetComponent<Health>();


	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            myHealth.adjustHealth(-10);
        }

        else if (Input.GetKeyDown(KeyCode.B))
        {
            myHealth.adjustHealth(10);
        }

    }
}
