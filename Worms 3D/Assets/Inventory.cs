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
     When using the methods below, you must provide a number you wish to increase Rockets or Grenades by
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
