using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Worked on by:
 * Ryan Madigan
 * Dean Kennelly
 * Evan Barry
 * Jack Gammon*/

    /*How to use this script:
     This script will increment and decrement health on button presses
     It will also access the health script component and access it's adjustHealth(). */

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
