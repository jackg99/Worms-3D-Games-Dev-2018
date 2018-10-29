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
        Inventory teamInv = new Inventory();


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



    //Inventory Code
    //Allows you to add an amount of rockets or grenades
    internal void addRockets(int increaseValue)
    {
        teamInv.setRockets(teamInv.getRockets() + increaseValue);
    }

    internal void addGrenades(int increaseValue)
    {
        teamInv.setGrenades(teamInv.getGrenades() + increaseValue);
    }

    //Allows you to remove an amount of rockets or grenades. You can not have negative rockets or grenades.
    internal void removeRockets(int decreaseValue)
    {
        if (teamInv.getRockets() > 0)
        {
            teamInv.setRockets(teamInv.getRockets() - decreaseValue);
        }
        else
        {
            teamInv.setRockets(0);
        }
    }

    internal void removeGrenades(int decreaseValue)
    {
        if(teamInv.getGrenades() > 0)
        {
            teamInv.setGrenades(teamInv.getGrenades() - decreaseValue);
        }
    }


    //Dumps the toString into the console for testing purposes
    internal void displayInventory()
    {
        Console.Write(teamInv.toString());
    }
    //End of Inventory Code

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

