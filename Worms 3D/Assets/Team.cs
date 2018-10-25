using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Team
    {
        List<WormControl> members;
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
}

