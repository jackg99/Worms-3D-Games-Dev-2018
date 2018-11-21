using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCameraControl : MonoBehaviour {
    internal float verticalAngle,horizontalAngle;
    private float rotationSpeed = 10;
    internal Vector3 target;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		 
	}

    internal void updateVerticalAngle(float v)
    {

        target -= v * rotationSpeed * Time.deltaTime * Vector3.up;
    }

    internal void updateHorizontalAngle(float v)
    {
        target += v * rotationSpeed * Time.deltaTime * transform.right;
    }
}
