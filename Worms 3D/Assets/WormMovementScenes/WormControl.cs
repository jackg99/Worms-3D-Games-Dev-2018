using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormControl : MonoBehaviour {
    //Define the direction the worm is facing and the falling speed (gravity)
    Vector3 direction, velocity, acceleration;
    float AmplitudeForWormSlither = 0.1f;
    float PeriodOfSlither = 1;
    PlayerControl myController;
    Team myTeam;
    

    int imOnTeam;
    int teamMember;



    //Define walking speed variable and turning speed variable
    float walkingSpeed = 2,turningSpeed = 45, jumpForce = 7;
    private float timeForSlither;

    internal void updateTeamColour(int teamId)
    {
        ourHealth.upDateColorTo(teamId);
    }

    internal void setActive(bool v)
    {
        isActive = v;
        ourHealth.wormActive(isActive);
        
    }

    bool isActive = false;


    enum Movement  {slither, jump, fall};

    Health ourHealth;






    // Use this for initialization
    void Awake () {
       // gameObject.SetActive(false);
        ourHealth = gameObject.AddComponent<Health>();
        ourHealth.Iam(this);
        myController = FindObjectOfType<PlayerControl>();

        velocity = new Vector3(0, 7, 0);
        acceleration = new Vector3(0, -9, 0);

        Movement movementMode;

        movementMode = Movement.slither;


        /* relocated from health script
         FloatingDisplay ourHealthDisplay;
         */

    }

    internal bool isWormActive()
    {
        return isActive;
    }

    // Update is called once per frame
    void Update ()
    {
        //Insert Switch Case for deciding movement mode of the Controlled Worm


        /*
        switch(somethingCool)
        {
            case 1: jumpCode();
                break;
            case 2: notJumpCode();
                break;
            default: wormMovement();
                    break;
        }
        */
        //shouldGoForward() method defines the key press (w)
        if (isActive)
        {

    
            
            if (shouldGoForward())
            {
                //Applies actual movement equation forward
                goForward();
                wormWalk();
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

            //shouldStrafeLeft() method defines the key press (q)
            if (shouldStrafeLeft())
            {
                strafeLeft();
            }
            //shouldStrafeRight() method defines the key press (e)
            if (shouldStrafeRight())
            {
                strafeRight();
            }
            if (shouldJump())
            {
                jump();
            }

            //The movement equation, updates position of the worm on key press
            transform.position += walkingSpeed * direction /*+ acceleration */* Time.deltaTime;

            //This allows the worm to stop when the key is released
            stop();
        }//End isActive

    }

    internal void introduction(PlayerControl playerControl)
    {
        myController = playerControl;
    }

    internal void yourDead()
    {
        myController.wormDead(this);

        Destroy(gameObject);

    }


    internal void YoureOnTeam(int j)
    {
      ourHealth.ImOnTeam(j);
        imOnTeam = j;
    }

    public int whatisMyTeam()
    {
        return imOnTeam;
    }

    public int whatMemberOfTeam()
    {
        teamMember = myTeam.memberId;
        return teamMember;
    }

    private bool shouldStrafeRight()
    {
        return Input.GetKey("e");
    }

    private void strafeRight()
    {
        direction = transform.right;
    }

    private bool shouldStrafeLeft()
    {
        return Input.GetKey("q");
    }

    private void strafeLeft()
    {
        direction = -transform.right;
    }

    private void wormMovement()
    {
        //shouldGoForward() method defines the key press (w)
        if (shouldGoForward())
        {
            //Applies actual movement equation forward
            goForward();
            wormWalk();
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

        if (shouldJump())
        {
            jump();
        }


        //The movement equation, updates position of the worm on key press
        transform.position += walkingSpeed * direction + acceleration * Time.deltaTime;

        //This allows the worm to stop when the key is released
        direction = Vector3.zero;
    }
    private void wormWalk()
    {
        timeForSlither += Time.deltaTime;
// print(( timeForSlither) * (2 * Mathf.PI) / PeriodOfSlither);
        foreach (Transform child in transform)
            child.localScale = new Vector3(  1 + AmplitudeForWormSlither * Mathf.Sin(((2 * Mathf.PI) * timeForSlither) / PeriodOfSlither)  , 1, 1);
;    }
    private void jump()
    {

        acceleration += Vector3.up * 10;

        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }

    private void stop()
    {
        direction = Vector3.zero;
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
        transform.Rotate(transform.up, -turningSpeed * Time.deltaTime);
    }

    private bool shouldRotateRight()
    {
        return Input.GetKey("d");
    }
    private void rotateRight()
    {
        transform.Rotate(transform.up, +turningSpeed * Time.deltaTime);
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

    //private void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.CompareTag("Player"))
    //    {
    //        if (thisProjectile == ProjectileType.Grenade)
    //        {
    //            ourHealth.adjustHealth(-30);
    //        }
    //    }
    //}
}
