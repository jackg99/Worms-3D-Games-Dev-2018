using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*How to use this script:
 This script is assigning values to game objects that are passed
 in the youAreA() based on it's projectile type.
 It transforms the object based on these values.*/

public class ProjectileControl : MonoBehaviour {
    Vector3 velocity, acceleration;

    float grenadeTimeToExplode = 5.0f;
    Quaternion grenaderotation;
    public float turningSpeed = 45;

    float AOE_radius;
    internal enum ProjectileType {Grenade, Missile, Bullet, Mortar };
    ProjectileType thisProjectile = ProjectileType.Missile;

    WormControl ourOwner;
    TimeAndDisplayCountup grendeTimer;
    private float MaxDamage;
    private readonly float max_damage_dist_ratio = 0.1f;



    // Use this for initialization
    void Start () {
        //velocity = new Vector3(0, 0, 3);
        //acceleration = new Vector3(0, 0,0);
        //grenaderotation =  Quaternion.Euler(1,1,1);


    }

    internal void youAreA(ProjectileType projectileType, Vector3 position, Vector3 direction, float speed, WormControl theOwner)
    {

        thisProjectile = projectileType;
        transform.position = position;
        velocity = speed * direction;
        ourOwner = theOwner;

        switch (thisProjectile)
        {
            case ProjectileType.Grenade:
       
                acceleration = new Vector3(0, -9.8f, 0);
                turningSpeed = 180;

                grendeTimer = gameObject.AddComponent<TimeAndDisplayCountup>();
                grendeTimer.setDuration(grenadeTimeToExplode);
                grendeTimer.startTimer();
                MaxDamage = 50;
                AOE_radius = 3;

                break;

            case ProjectileType.Missile:

                acceleration = new Vector3(0, 0, 0);
                turningSpeed = 360;
                AOE_radius = 10;
                MaxDamage = 100;
                break;

            case ProjectileType.Bullet:
   
                acceleration = new Vector3(0, 0, 0);
                break;

            case ProjectileType.Mortar:

                acceleration = new Vector3(0, -9.8f, 0);
                break;
        }
    }

    // Update is called once per frame
    void Update() {

        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        switch (thisProjectile) {

            case ProjectileType.Missile:
        transform.Rotate(transform.forward, turningSpeed * Time.deltaTime); // rocket
               
                break;

            case ProjectileType.Grenade:

        transform.Rotate(transform.right, turningSpeed * Time.deltaTime); // Grenade
                if (grendeTimer.isOver())
                    Explode();

                break;


    }

    }

    public void Explode()
    {
        print("Im exploding");

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, AOE_radius);

        foreach (Collider col in hitColliders)
        {
            Health victim = col.gameObject.GetComponent<Health>();
            if (victim)
            {
                victim.printHello();
                victim.adjustHealth(calculateDamage(victim.transform.position));
            }

        }

        Destroy(gameObject);

    }

    private int calculateDamage(Vector3 position)
    {
        float distance = Vector3.Distance(position, transform.position);
        if (distance < max_damage_dist_ratio * AOE_radius)
            return (int)-MaxDamage;


        return (int) Mathf.Clamp((-MaxDamage * (AOE_radius - distance) / ((1.0f - max_damage_dist_ratio) * AOE_radius)),-MaxDamage,0);

      
    }

    private void OnCollisionEnter(Collision col)
    {
        print("Ouch");

        switch (thisProjectile)
        {

            case ProjectileType.Grenade:


                transform.position -= velocity * Time.deltaTime;

                velocity = new Vector3(velocity.x, -0.5f * velocity.y, velocity.z);
                break;

            case ProjectileType.Missile:
                    
                for (int i = 0;i<12;i++)
                { print(calculateDamage(transform.position + AOE_radius * i / 10 * Vector3.left));
                }



                Explode();

                break;
    }

    }


}


 
     
