using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*How to use this script:
 Setting up a projectile prefab object and 
 instantiating the prefabs as game objects. 
 It acesses the projectile control script and the youAreA().
 It passes in the arguments for the projectile type, position, direction, speed for the game object*/

public class ProjectileSpawner : MonoBehaviour {
    public UnityEngine.Object grenadePrefab;
    public UnityEngine.Object MissilePrefab;

    bool firingMissile = false, firingBullet = false;


    TimeAndDisplayCountup strengthMeter;
    PowerDisplay GrenadeDisplayTest;
    private float MaxGrenadeSpeed = 40;
    AimCameraControl ourAimCam;
    GameObject crosshairs;
    WormControl ourOwner;
    private Inventory myTeamInventory;


    // public FloatingDisplay strengthMeterDisplay;



    // Use this for initialization
    void Start () {

     ourOwner = gameObject.GetComponent<WormControl>();

    }

    // Update is called once per frame
    void Update() {
        if (ourOwner.isWormActive())
        {
            //Checks if G is pressed and that the team's inventory has a grenade
            if (Input.GetKey(KeyCode.G)  && (myTeamInventory.getGrenades() > 0))
            {

                
                if (GrenadeDisplayTest)  // grenade strength being calculated
                {
                    GrenadeDisplayTest.setDisplay(((int)(strengthMeter.relativePercentage())).ToString());

                    //strengthMeterDisplay.transform.localPosition += 0.5f * Vector3.up;                    I tried to make the grenade strength meter go above the health but i think ill just go for hiding the health and making it re-appear
                    // strengthMeterDisplay.transform.position += 0.5f * Vector3.up;
                    if (strengthMeter.relative() > 1.0f) createGrenade();
                }
                else   // Start of launch grenade
                {
                    GrenadeDisplayTest = gameObject.AddComponent<PowerDisplay>();
                    strengthMeter = gameObject.AddComponent<TimeAndDisplayCountup>();
                    strengthMeter.setDuration(5.0f);
                    strengthMeter.startTimer();
                    //strengthMeterDisplay.transform.localPosition = 2.5f * Vector3.up;
                }


            }

            else if(myTeamInventory.getGrenades() == 0)
            {
                Debug.Log("No Grenades in Inventory (P to add)");
            }

            else   
            {

                if (strengthMeter)

                {
                    createGrenade();

                }

            }


            if (Input.GetKey(KeyCode.M))
            {
                if (ourAimCam)
                {

                    print("Camera made");
                   ourAimCam.transform.Rotate(Vector3.up, Input.GetAxis("Horizontal"));
                   ourAimCam.transform.Rotate(transform.right, Input.GetAxis("Vertical"));

                    if (crosshairs)
                    {
                        crosshairs.transform.position = ourAimCam.target;
                    }
                    if (Input.GetMouseButtonDown(0))
                    {
                        GameObject newProjectileGO = (GameObject)Instantiate(grenadePrefab);
                        ProjectileControl newProjectileScript = newProjectileGO.GetComponent<ProjectileControl>();

                        newProjectileScript.youAreA(ProjectileControl.ProjectileType.Missile, ourAimCam.transform.position, (ourAimCam.target -  ourAimCam.transform.position).normalized, 15.0f, ourOwner);
                        DestroyAimCam();
                     //   ourOwner.setActive(false);
                    }
                }

                else
                {
                    print("Adding Aim Camera");
                    GameObject cam = new GameObject("Aiming Camera");
                    cam.AddComponent<Camera>();
                  
                    ourAimCam = cam.gameObject.AddComponent<AimCameraControl>();

                    ourAimCam.transform.position = transform.position + 2.0f * Vector3.up - 2.0f * transform.forward;
                    ourAimCam.transform.rotation = transform.rotation;
                    ourAimCam.target = transform.position + 50 * transform.forward;


                    crosshairs = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    firingMissile = true;

                     
                 }
                    

            }

            else  // M released (or not pressed)
            {
                if (firingMissile)
                {
                    Destroy(ourAimCam.gameObject);
                    Destroy(crosshairs);
                    firingMissile = false;
                }

            }

            
            //Fire Bullet
            if (Input.GetKey(KeyCode.F))
            {
                if (ourAimCam)
                {
                    ourAimCam.transform.Rotate(Vector3.up, Input.GetAxis("Horizontal"));
                    ourAimCam.transform.Rotate(transform.right, Input.GetAxis("Vertical"));
                    if (crosshairs)
                    {
                        crosshairs.transform.position = ourAimCam.transform.position + 50.0f * ourAimCam.transform.forward;
                    }
                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.DrawRay(ourAimCam.transform.position, ourAimCam.transform.forward * 1000, Color.blue, 10.0f);
                        Ray bullets = new Ray(ourAimCam.transform.position, ourAimCam.transform.forward);
                        RaycastHit info = new RaycastHit();

                        if (Physics.Raycast(bullets, out info))
                        {
                            Health healthOfVictim = info.collider.GetComponent<Health>();
                            if (healthOfVictim)
                                healthOfVictim.adjustHealth(-20);
                          
                        }

                        

                        DestroyAimCam();
                        ourOwner.setActive(false);
                    }
                }

                else
                {
                    GameObject cam = new GameObject("Bullet Camera");
                    cam.AddComponent<Camera>();
                    ourAimCam = cam.gameObject.AddComponent<AimCameraControl>();

                    ourAimCam.transform.position = transform.position + 2.0f * Vector3.up - 2.0f * transform.forward;
                    ourAimCam.transform.rotation = transform.rotation;

                    crosshairs = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

                    firingBullet = true;

                }


            }

            else  // F released (or not pressed)
            {
                if (firingBullet)
                {
                    firingBullet = false;
                    Destroy(ourAimCam.gameObject);
                    Destroy(crosshairs);
                }

            }



        }
        }

    internal void InventoryLink(Inventory teamInventory)
    {
        myTeamInventory = teamInventory;
    }

    private void DestroyAimCam()
    {
        Destroy(crosshairs);
        Destroy(ourAimCam.gameObject,2.0f);
    }

    private void createGrenade()
        {
            //Removes a grenade from the inventory when a grenade is launched
            myTeamInventory.removeGrenades(1);
            //

            GameObject newProjectileGO = (GameObject)Instantiate(grenadePrefab);
            ProjectileControl newProjectileScript = newProjectileGO.GetComponent<ProjectileControl>();

            newProjectileScript.youAreA(ProjectileControl.ProjectileType.Grenade, transform.position  + 2*transform.forward+ 2*transform.up , (transform.forward + Vector3.up).normalized,
            MaxGrenadeSpeed * strengthMeter.relative(),ourOwner);

            Destroy(strengthMeter);

            GrenadeDisplayTest.manuallyDestroy();


        }

    

}
