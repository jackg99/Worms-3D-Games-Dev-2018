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


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject newProjectileGO = (GameObject)Instantiate(grenadePrefab);
            ProjectileControl newProjectileScript = newProjectileGO.GetComponent<ProjectileControl>();

            newProjectileScript.youAreA(ProjectileControl.ProjectileType.Grenade, new Vector3(2,3,4), new Vector3(1,0,0),  5.0f );  
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            GameObject newProjectileGO = (GameObject)Instantiate(grenadePrefab);
            ProjectileControl newProjectileScript = newProjectileGO.GetComponent<ProjectileControl>();

            newProjectileScript.youAreA(ProjectileControl.ProjectileType.Missile, new Vector3(-2, 3, 4), new Vector3(0, 1, 0), 15.0f);
        }

    }
}
