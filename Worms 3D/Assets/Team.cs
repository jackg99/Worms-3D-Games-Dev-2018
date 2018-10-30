using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Team
    {
        List<WormControl> members;
        int index_of_CurrentlyActive_Worm = 0;
        int teamId;
        int _numberofMembers;
        public int notGettingBlamedForThat = -1;
        public Team(int Id, int number_of_members)
    {
        teamId = Id;

        _numberofMembers = number_of_members;
        members = new List<WormControl>();

        }
    internal void updateWormColours()
    {
        foreach (WormControl worm in members)
        {
            worm.updateTeamColour(teamId);

        }
    }
    internal void AddMember(WormControl ourNewWorm)
    {

        members.Add(ourNewWorm);
    }

    internal WormControl  incWorm()
    {   
        index_of_CurrentlyActive_Worm = (index_of_CurrentlyActive_Worm + 1) % _numberofMembers;
        Debug.Log("Worm index is " + index_of_CurrentlyActive_Worm.ToString());
        members[index_of_CurrentlyActive_Worm].setActive(true);
        return members[index_of_CurrentlyActive_Worm];
    }
}

