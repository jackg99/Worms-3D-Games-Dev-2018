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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    int numberOfTeams = 4;

    int current_Worm_Index = -1;
    int current_Team_Index = -1;
    List<WormControl> allWorms;
    List<Team> allTeams;


    public UnityEngine.Object WormPrefab;
    bool someWormActive = false;
    private int numTeams;
    private int numWormsPerTeam;


    // Use this for initialization
    void Start () {
        allWorms = new List<WormControl>();




        numTeams = 4;
        numWormsPerTeam = 4;
        allTeams = new List<Team>();

        for (int teamId = 0; teamId < numTeams; teamId++)
            allTeams.Add(new Team(teamId, numWormsPerTeam));



        spawnWorms();

        foreach (Team team in allTeams)
        {
            team.updateWormColours();
        }
    }
	
	// Update is called once per frame
	void Update () {
      
        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
        //    if (someWormActive)
        //    {
        //        allWorms[current_Worm_Index].setActive(false);
        //    }
            
        //    someWormActive = true;

        //    current_Worm_Index = (current_Worm_Index + 1) % allWorms.Count;
        //    allWorms[current_Worm_Index].setActive(true); 
        //}

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (someWormActive)
            allTeams[current_Team_Index].setCurrentWormInactive();

            someWormActive = true;

            nextTeamSelect();
            nextWormSelect();
        }
    }

    void spawnWorms()
    {
        for (int teamId = 0; teamId < numberOfTeams; teamId++)
            for(int playerId = 0; playerId < numWormsPerTeam; playerId++)
            {
            
                GameObject temp = (GameObject) Instantiate(WormPrefab,new Vector3(4*teamId,0.2f,4*playerId), Quaternion.identity);
                WormControl ourNewWorm = temp.GetComponent<WormControl>();
                ourNewWorm.introduction(this);
                allWorms.Add(ourNewWorm);
                allTeams[teamId].AddMember(ourNewWorm);
                ourNewWorm.YoureOnTeam(teamId);

         
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

    internal void nextTeamSelect()
    {

        // This code iterates though the list of teams

            //allTeams[current_Team_Index].setCurrentWormInactive();
            current_Team_Index = (current_Team_Index + 1) % numTeams;
        
    }

    internal void nextWormSelect()
    {

        // This code is attempting to iterate through the worms on a team, while keeping track of which 
        // worm is currently selected on the team.
        
        allTeams[current_Team_Index].incWorm(); // <----
            //current_Worm_Index = (current_Worm_Index + 1) % allTeams.Count;
        //allWorms[current_Worm_Index].setActive(true);
    }

    internal void wormDead(WormControl wormControl)
    {
        throw new NotImplementedException();
    }
}
