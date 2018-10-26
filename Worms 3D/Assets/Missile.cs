using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Missile : MonoBehaviour {

    ProjectileControl ourControl;
        

	// Use this for initialization
	void Start () {

        ourControl = gameObject.GetComponent<ProjectileControl>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        ourControl.Explode();
        
    }
}
