using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCameraScript : MonoBehaviour {

    float camera_height = 10;
    float angle = 0;
    float rotationSpeed = 1;
    float horz_distance = 10;

    WormControl focusWorm;
    private float minHorzDist = 5;
    private float maxHorDist = 20;

    // Use this for initialization
    void Start () {
        transform.position += 10* Vector3.up;




	}
	
	// Update is called once per frame
	void Update () {

        horz_distance += Input.GetAxis("Mouse ScrollWheel") * rotationSpeed;
        horz_distance = Mathf.Clamp(horz_distance, minHorzDist, maxHorDist);
        if (Input.GetKey(KeyCode.Mouse2))
        {   camera_height += Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;
            angle += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
          
        }
        if (focusWorm)
        {
            transform.position = focusWorm.transform.position + horz_distance * new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) + Vector3.up * camera_height;
            transform.LookAt(focusWorm.transform.position);
        }

    


	}

    internal void newWormIs(WormControl currentActiveWorm)
    {
        focusWorm = currentActiveWorm;
    }
}
