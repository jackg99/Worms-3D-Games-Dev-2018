using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class Team
    {

        public List<WormControl> members;
        int index_of_CurrentlyActive_Worm = -1;
        int teamId;
        int _numberofMembers;
        public int memberId = 0;
        internal Inventory teamInventory;

    public Team(int Id, int number_of_members)
    {
        teamId = Id;

        _numberofMembers = number_of_members;
        members = new List<WormControl>();

        //GameObject score = new GameObject("Score");
        //TextMesh scoreText = score.AddComponent<TextMesh>();
        //scoreText.text = "Score";
        //ScoreScript scoreScript = score.AddComponent<ScoreScript>();
        


        teamInventory = new Inventory();


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

        while (members[index_of_CurrentlyActive_Worm] == null)
        {
            index_of_CurrentlyActive_Worm = (index_of_CurrentlyActive_Worm + 1) % _numberofMembers;
        }
        Debug.Log("Worm index is " + index_of_CurrentlyActive_Worm.ToString());
        members[index_of_CurrentlyActive_Worm].setActive(true);
        return members[index_of_CurrentlyActive_Worm];
    }
}

