using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*How to use this script:
 Setting up a projectile prefab object and 
 instantiating the prefabs as game objects. 
 It acesses the projectile control script and the youAreA().
 It passes in the arguments for the projectile type, position, direction, speed for the game object*/

public class ProjectileSpawner : MonoBehaviour {

    public Object grenadePrefab;
    public Object MissilePrefab;
    FloatingDisplay strengthMeterDisplay;
    TimeAndDisplayCountup strengthMeter;
    private float MaxGrenadeSpeed = 40;
    

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        
            if (Input.GetKey(KeyCode.G))
            {
                if (strengthMeterDisplay)  // grenade strength being calculated
                {
                    strengthMeterDisplay.setDisplay(strengthMeter.relativePercentage().ToString());

                    if (strengthMeter.relative() > 1.0f) createGrenade();
                }
                else   // STart of launch grenade
                {
                    strengthMeterDisplay = gameObject.AddComponent<FloatingDisplay>();
                    strengthMeter = gameObject.AddComponent<TimeAndDisplayCountup>();
                    strengthMeter.setDuration(5.0f);
                    strengthMeter.startTimer();


                }

            }

            else
            {
                if (strengthMeterDisplay)
                {
                    createGrenade();

                }

            }


            if (Input.GetKeyDown(KeyCode.M))
            {
                GameObject newProjectileGO = (GameObject)Instantiate(grenadePrefab);
                ProjectileControl newProjectileScript = newProjectileGO.GetComponent<ProjectileControl>();

                newProjectileScript.youAreA(ProjectileControl.ProjectileType.Missile, new Vector3(-2, 3, 4), new Vector3(0, 1, 0), 15.0f);
            }

        }

        private void createGrenade()
        {
            GameObject newProjectileGO = (GameObject)Instantiate(grenadePrefab);
            ProjectileControl newProjectileScript = newProjectileGO.GetComponent<ProjectileControl>();

            newProjectileScript.youAreA(ProjectileControl.ProjectileType.Grenade, transform.position, (transform.forward + Vector3.up).normalized,
            MaxGrenadeSpeed * strengthMeter.relative());

            Destroy(strengthMeter);

            strengthMeterDisplay.manuallyDestroy();
        }
    }
    
}
