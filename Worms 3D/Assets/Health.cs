using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Worked on by:
 * Ryan Madigan 
 * Dean Kennelly
 * Evan Barry 
 * Jack Gammon */

public class Health : MonoBehaviour {

    public int health;
    public int maxHealth;


	// Use this for initialization
	void Start () {

		if(gameObject.tag=="Player")
        {
            health = 100;
            maxHealth = 200;
        }

        if(gameObject.tag=="Wall")
        {
            health = 500;
        }
	}
	
	// Update is called once per frame
	void Update () {

        
		
	}

    public void adjustHealth(int hit)
    {
        health += hit;

        if(health<=0)
        {
            death();
        }

        if(gameObject.tag=="Player" && health>maxHealth)
        {
            health = 200;
        }

    }

    void death()
    {
        Debug.Log("You dead");

        Destroy(gameObject);
    }
}
