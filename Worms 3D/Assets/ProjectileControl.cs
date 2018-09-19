using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileControl : MonoBehaviour {
    Vector3 velocity, acceleration;
    Quaternion grenaderotation;
    float turningSpeed = 45;

    // Use this for initialization
    void Start () {
        velocity = new Vector3(0, 0, 3);
        acceleration = new Vector3(0, 0,0);
        grenaderotation =  Quaternion.Euler(1,1,1);
		
	}
	
	// Update is called once per frame
	void Update () {

        velocity += acceleration * Time.deltaTime; 
        transform.position += velocity * Time.deltaTime;
        transform.Rotate(transform.forward, turningSpeed*Time.deltaTime);

        
		
	}


}


 
     
