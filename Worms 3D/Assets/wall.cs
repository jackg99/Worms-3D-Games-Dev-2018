using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour {
    Health wallHealth;
    public bool isDestructable;
    public int wallHealthTest=1; // This varaible is only for testing purposes
   
    

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
            wallHealthTest = 100; // testing purposes only
        }
	}
	
	// Update is called once per frame
	void Update () {

        if(wallHealthTest<=0)
        {
            Destroy(gameObject);
        }
		
	}

    //I only created this for testing as I got errors

  //  private void OnCollisionEnter(Collision collision)
    //{
      //  if (gameObject.tag != "SurroundingWall")
        //{
          //  wallHealthTest = wallHealthTest - 10;
        //}

    //}


}
