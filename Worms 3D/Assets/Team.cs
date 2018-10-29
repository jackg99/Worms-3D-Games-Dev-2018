using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Team
    {
        List<WormControl> members;
        int teamId;
        int _numberofMembers;
        int memberId = -1;
        //bool someWormActive = false;
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
    public int getMemberId()
    {
        return memberId;
    }

    public void setCurrentWormInactive()
    {
        members[memberId].setActive(false);
        
    }

    internal void incWorm()
    {

        
        //if (someWormActive)
        //{
        //    members[memberId].setActive(false);
        //}

        //someWormActive = true;
            
        memberId = (memberId + 1) % _numberofMembers;

        if(members[memberId] == null)
        {
            memberId = (memberId + 1) % _numberofMembers;
        }

        members[memberId].setActive(true);
    }

    
}

