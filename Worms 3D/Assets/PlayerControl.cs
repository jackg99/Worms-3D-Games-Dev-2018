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
    int current_Worm_Index = -1;
    List<WormControl> allWorms;
    List<List<WormControl>> allTeams;
    List<WormControl> tempTeam;
    List<WormControl> team1;
    List<WormControl> team2;
    List<WormControl> team3;
    List<WormControl> team4;
    public Object WormPrefab;
    bool someWormActive = false;
    private int numTeams;
    private int numWormsPerTeam;


    // Use this for initialization
    void Start () {
        allWorms = new List<WormControl>();
        tempTeam = new List<WormControl>();

        numTeams = 3;
        numWormsPerTeam = 4;
        allTeams = new List<List<WormControl>>(numTeams);

        for (int i = 0; i < numTeams; i++)
            allTeams.Add(spawnTeam(i,i));

        //Team code
       
        team1 = new List<WormControl>();


        //spawnWorms();
     
        //spawnTeam(team1,1);
        //spawnTeam(team2,2);
        //spawnTeam(team3,3);
        //spawnTeam(team4,4);

        Debug.Log(team1.Count);
    }
	
	// Update is called once per frame
	void Update () {
        /*
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (someWormActive)
            {
                allWorms[current_Worm_Index].setActive(false);
            }
            
            someWormActive = true;

                current_Worm_Index = (current_Worm_Index + 1) % allWorms.Count;
            allWorms[current_Worm_Index].setActive(true); 
        }
        */
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (someWormActive)
            {
                team1[current_Worm_Index].setActive(false);
            }

            someWormActive = true;

            current_Worm_Index = (current_Worm_Index + 1) % team1.Count;
            team1[current_Worm_Index].setActive(true);
        }
    }

    void spawnWorms()
    {
        for (int i = 0; i < 4; i++)
            for(int j = 0; j < 4; j++)
            {
            
                GameObject temp = (GameObject) Instantiate(WormPrefab,new Vector3(4*i,0.2f,4*j), Quaternion.identity);
                allWorms.Add(temp.GetComponent<WormControl>());

         
            }
    }

    List<WormControl> spawnTeam(int teamId,  int space)
    {
        List<WormControl> hold = new List<WormControl>();
        for (int j = 0; j < numWormsPerTeam; j++)
        {
            GameObject temp = (GameObject)Instantiate(WormPrefab, new Vector3(4 * space, 0.2f, 4 * j), Quaternion.identity);
            hold.Add(temp.GetComponent<WormControl>());
            hold[hold.Count - 1].YoureOnTeam(teamId);
        }
        return hold;
    }
}
