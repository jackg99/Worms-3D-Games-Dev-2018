//Inventory.cs by Daragh Carroll t00201097 26/10/2018
/*
    This simple instanceable class tracks how many grenades and rockets a team can have.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {
    private int rockets;
    private int grenades;

    //Mutators
    public void setRockets(int rockets)
    {
        rockets = this.rockets;
    }

    public void setGrenades(int grenades)
    {
        grenades = this.grenades;
    }

    //Accessors
    public int getRockets()
    {
        return this.rockets;
    }

    public int getGrenades()
    {
        return this.grenades;
    }

    //Constructors

        //No Args
    public Inventory()
    {
        this.grenades = 0;
        this.rockets = 0;
    }


        //2 Args
    public Inventory(int rockets, int grenades)
    {
        setRockets(rockets);
        setGrenades(grenades);
    }

    //toString
    public string toString()
    {
        return "Rockets: " + getRockets() + "\\nGrenades: " + getGrenades();
    }
}
