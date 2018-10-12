/*
 * PlayerControl.cs
 * Programming by:
 * - Ian O'Regan
 * - Liam Dowling
 * - Ryan Cosheril
 * - Modestas Cepulis
 * - Emma Fitzgerald
 * - Daragh Carroll
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    int current_Worm_Index = 0;
    List<WormControl> allWorms;
    //Testcode -- Remove if everything goes wrong
    List<WormControl> team1;
    //End testcode
    public Object WormPrefab;


    // Use this for initialization
    void Start () {
        allWorms = new List<WormControl>();
        //testcode -- Remove if everything goes wrong
        team1 = new List<WormControl>();
        //end testcode
        spawnWorms();
        allWorms[current_Worm_Index].setActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            allWorms[current_Worm_Index].setActive(false);
            current_Worm_Index = (current_Worm_Index + 1) % allWorms.Count;
            allWorms[current_Worm_Index].setActive(true); 


        }
	}

    void spawnWorms()
    {
        for (int i = 0; i < 4; i++)
            for(int j = 0; j < 4; j++)
            {
            
                GameObject temp = (GameObject) Instantiate(WormPrefab,new Vector3(2*i,0,2*j), Quaternion.identity);
                allWorms.Add(temp.GetComponent<WormControl>());

                //Testcode -- Remove if everything goes wrong
                for (int x = 0; x < 4; x++)
                {
                    team1.Add(temp.GetComponent<WormControl>());
                }

                //End of testcode
            }


    }
}
