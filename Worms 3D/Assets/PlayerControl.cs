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

    int numberOfTeams = 4;

    int current_Worm_Index = -1;
    int current_Team_Index = -1;
    List<WormControl> allWorms;
    List<Team> allTeams;
    WormControl currentActiveWorm;


    public Object WormPrefab;
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

        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            nextTeamSelect();
            nextWormSelect();

        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            nextWormSelect();
        }


    }

    void spawnWorms()
    {
        for (int teamId = 0; teamId < numberOfTeams; teamId++)
            for(int wormId = 0; wormId < numWormsPerTeam; wormId++)
            {
            
                GameObject temp = (GameObject) Instantiate(WormPrefab,new Vector3(4*teamId,0.2f,4*wormId), Quaternion.identity);
                WormControl ourNewWorm = temp.GetComponent<WormControl>();
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
        current_Team_Index = (current_Team_Index + 1) % allTeams.Count;
        print("New Team index is " + current_Team_Index.ToString() +" out of " + allTeams.Count.ToString());
    }

    internal void nextWormSelect()
    {
        if (currentActiveWorm)
        {
            currentActiveWorm.setActive(false);
        }

        currentActiveWorm = allTeams[current_Team_Index].incWorm(); // <----

    }
     public void wormDead(WormControl worm)
    {

        allTeams[worm.whatisMyTeam()].members.Remove(worm);
        print("Worm Removed from list");

    }
}
