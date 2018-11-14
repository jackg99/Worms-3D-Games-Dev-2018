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
    //PlayerControl player;
    public UnityEngine.Object grenadePrefab;
    public UnityEngine.Object MissilePrefab;
    PowerDisplay Strengthmeter;
    TimeAndDisplayCountup strengthMeter;
    private float MaxGrenadeSpeed = 40;
    AimCameraControl ourAimCam;
    GameObject crosshairs;
    WormControl ourOwner;

    
    

    // Use this for initialization
    void Start () {

     ourOwner = gameObject.GetComponent<WormControl>();

    }

    // Update is called once per frame
    void Update() {
        if (ourOwner.isWormActive())
        {
            if (Input.GetKey(KeyCode.G))
            {

                //Checks that the player inventory has a grenade
                //if (player.allTeams[player.current_Team_Index].teamInventory.getGrenades() > 0)
                //{
                if (strengthMeterDisplay)  // grenade strength being calculated
                {
                     strengthMeterDisplay.setDisplay(strengthMeter.relativePercentage().ToString());
                
                     //strengthMeterDisplay.transform.localPosition += 0.5f * Vector3.up;                    I tried to make the grenade strength meter go above the health but i think ill just go for hiding the health and making it re-appear
                     // strengthMeterDisplay.transform.position += 0.5f * Vector3.up;
                     if (strengthMeter.relative() > 1.0f) createGrenade();
                }
                else   // STart of launch grenade
                {
                     strengthMeterDisplay = gameObject.AddComponent<FloatingDisplay>();
                     strengthMeter = gameObject.AddComponent<TimeAndDisplayCountup>();
                     strengthMeter.setDuration(5.0f);
                     strengthMeter.startTimer();
                     //strengthMeterDisplay.transform.localPosition = 2.5f * Vector3.up;

                }

                    //Removes a grenade from the inventory
                    //player.allTeams[player.current_Team_Index].teamInventory.removeGrenades(1);

                //}
                //else
                //{
                    //Debug.Log("No Grenades in Inventory (P to add)");
                //}

            }

            else
            {
                if (Strengthmeter)
                {
                    createGrenade();

                }

            }


            if (Input.GetKey(KeyCode.M))
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
                        GameObject newProjectileGO = (GameObject)Instantiate(grenadePrefab);
                        ProjectileControl newProjectileScript = newProjectileGO.GetComponent<ProjectileControl>();

                        newProjectileScript.youAreA(ProjectileControl.ProjectileType.Missile, ourAimCam.transform.position, ourAimCam.transform.forward, 15.0f, ourOwner);
                        DestroyAimCam();
                        ourOwner.setActive(false);
                    }
                }

                else
                {
                    GameObject cam = new GameObject();
                    cam.AddComponent<Camera>();
                    ourAimCam = cam.gameObject.AddComponent<AimCameraControl>();

                    ourAimCam.transform.position = transform.position + 2.0f * Vector3.up - 2.0f * transform.forward;
                    ourAimCam.transform.rotation = transform.rotation;

                    crosshairs = GameObject.CreatePrimitive(PrimitiveType.Sphere);


                     
                        }
                    

            }

            else  // M released (or not pressed)
            {
                if (ourAimCam)
                {
                    Destroy(ourAimCam.gameObject);
                    Destroy(crosshairs);
                }

            }
        }
        }

    private void DestroyAimCam()
    {
        Destroy(crosshairs);
        Destroy(ourAimCam.gameObject,2.0f);
    }

    private void createGrenade()
        {
            GameObject newProjectileGO = (GameObject)Instantiate(grenadePrefab);
            ProjectileControl newProjectileScript = newProjectileGO.GetComponent<ProjectileControl>();

            newProjectileScript.youAreA(ProjectileControl.ProjectileType.Grenade, transform.position  + 2*transform.forward+ 2*transform.up , (transform.forward + Vector3.up).normalized,
            MaxGrenadeSpeed * strengthMeter.relative(),ourOwner);

            Destroy(strengthMeter);

            Strengthmeter.manuallyDestroy();
        }

    

}
