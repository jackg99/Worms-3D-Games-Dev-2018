using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormControl : MonoBehaviour {
    //Define the direction the worm is facing and the falling speed (gravity)
    Vector3 direction, velocity, acceleration;

    //Define walking speed variable and turning speed variable
    float walkingSpeed = 2,turningSpeed = 45, jumpForce = 7;


    // Use this for initialization
    void Start () {
        velocity = new Vector3(0, 7, 0);
        acceleration = new Vector3(0, -9, 0);

		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //shouldGoForward() method defines the key press (w)
        if (shouldGoForward())
        {
            //Applies actual movement equation forward
            goForward();
        }

        //shouldGoBack() method defines the key press (s)
        if (shouldGoBackwards())
        {
            //Applies actual movement equation backward
            goBackwards();
        }

        //shouldRotateLeft() method defines the key press (a)
        if (shouldRotateLeft())
        {
            //Applies actual movement equation left
            rotateLeft();
        }

        //shouldRotateRight() method defines the key press (d)
        if (shouldRotateRight())
        {
            //Applies actual movement equation right
            rotateRight();
        }

        if(shouldJump())
        {
            jump();
        }


        //The movement equation, updates position of the worm on key press
        transform.position += walkingSpeed* direction + acceleration * Time.deltaTime;

        //This allows the worm to stop when the key is released
        direction = Vector3.zero;
    }

    private void jump()
    {
        transform.position += velocity;
    }

    private bool shouldJump()
    {
        return Input.GetKeyDown("z");
    }

    private bool shouldRotateLeft()
    {
        return Input.GetKey("a");
    }

    private void rotateLeft()
    {
        transform.Rotate(transform.up, turningSpeed * Time.deltaTime);
    }

    private bool shouldRotateRight()
    {
        return Input.GetKey("d");
    }
    private void rotateRight()
    {
        transform.Rotate(transform.up, -turningSpeed * Time.deltaTime);
    }

    private void goBackwards()
    {
        direction = -transform.forward;
    }

    private bool shouldGoBackwards()
    {
        return Input.GetKey("s");
    }

    void goForward()
    {

        direction = transform.forward;
        

    }
    private  bool shouldGoForward()
    {
        return Input.GetKey("w");
    }
}
