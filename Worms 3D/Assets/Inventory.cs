//Inventory.cs by Daragh Carroll t00201097 26/10/2018
/*
    This simple instantiable class :
    1. Tracks how many Rockets and Grenades each team has
    2. Allows Rockets and Grenades to be added to the inventory of each team
    3. Allows the inventory to be displayed (For now it just dumps the toString out to the console 
    due to lack of a GUI)

    Inventory is instanced in Team.cs four times to allow individual teams to have inventories
    It links from there into WormControl and then into ProjectileSpawner using methods to allow
    ProjectileSpawner access to Grenade information
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {
    private int rockets;
    private int grenades;

    //Mutators

    public void setRockets(int newRocketAmount)
    {
         this.rockets = newRocketAmount;
    }

    public void setGrenades(int newGrenadeAmount)
    {
        this.grenades = newGrenadeAmount;
    }

    //Accessors
    public int getRockets()
    {
        return rockets;
    }

    public int getGrenades()
    {
        return grenades;
    }

    //Constructors

        //No Args
    public Inventory()
    {
        grenades = 0;
        rockets = 0;
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
        return "Rockets: " + getRockets() + "  ||  Grenades: " + getGrenades();
    }

    /*
     The methods below require an integer parameter to increase or decrease the rockets and grenades
     Example method calls:
     allTeams[1].teamInventory.addRockets(2);
     allTeams[3].teamInventory.addGrenades(1);
     allTeams[2].teamInventory.removeGrenades(4);
     allTeams[4].teamInventory.removeRockets(2);
    */

    internal void addRockets(int increaseValue)
    {
        setRockets(getRockets() + increaseValue);
        Debug.Log("Added " + increaseValue + " Rockets");
    }
    internal void addGrenades(int increaseValue)
    {
        setGrenades(getGrenades() + increaseValue);
        Debug.Log("Added " + increaseValue + " Grenades");
    }

    //Allows you to remove an amount of rockets or grenades. You can not have negative rockets or grenades.
    internal void removeRockets(int decreaseValue)
    {
        if (getRockets() > 0)
        {
            setRockets(getRockets() - decreaseValue);
            Debug.Log("Removed " + decreaseValue + " Rockets");
        }
        else
        {
            setRockets(0);
            Debug.Log("No Rockets to Remove");
        }
    }
    internal void removeGrenades(int decreaseValue)
    {
        if (getGrenades() > 0)
        {
            setGrenades(getGrenades() - decreaseValue);
            Debug.Log("Removed " + decreaseValue + " Grenades");
        }
        else
        {
            setGrenades(0);
            Debug.Log("No Grenades to Remove");
        }
    }

    //Dumps the toString into the console for testing purposes
    internal void displayInventory()
    {
        Debug.Log(toString());
    }
}
