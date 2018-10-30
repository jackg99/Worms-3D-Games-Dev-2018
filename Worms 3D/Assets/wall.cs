using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour {
    Health wallHealth;
    bool isDestructable;
   
    

	// Use this for initialization
	void Start () {
        wallHealth = gameObject.GetComponent<Health>();
        
        if(gameObject.tag == "SurroundingWall")
        {
            isDestructable = false;
        }
        else
        {
            isDestructable = true;
          //  wallHealth.health = 500;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if(wallHealth.health<=0)
        {
            Destroy(gameObject);
        }
		
	}

  
}
