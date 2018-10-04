//ItemPickup.cs by Emma Fitzgerald, Daragh Carroll and Modestas Cepulis
/*
    For an object to pick up an item using this code, it must contain the method 'justPickedup()'.
    'justPickedup' contains the three parameters dictated below: 'thisItemIs', 'valueOf'and 'numberOf'.
    'thisItemIs' distinguishes between the different enums itemType to dictate what type of item the player picked up. For example, is the item Ammo or Health?.
    'valueOf'
    'numberOf' dictates the amount of an item you recieve. For example, you pick up and ammo box and receive 2 rockets.

    The method will appear as below in the player object code:

    internal void justPickedup(ItemPickup.itemType thisItemIs, float valueOf, float numberOf)
    {
      <<Add code that is executed by the worm when the item is picked up. For example : Increase health by 50, Ammo by 3, Add Rocket Launcher to Inventory, etc.>>
    }

 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {
    float turningSpeed = 50.0f;
    internal enum itemType { Health, Ammo, Weapon, Armour }

    //Declares what type of item this gameObject represents.
    internal itemType thisItemIs = itemType.Health;

    float valueOf = 50;

    //Dictates the amount of an item you recieve.
    float numberOf = 20;

	// Update is called once per frame
	void Update () {
        rotateLeft();
	}

    private void rotateLeft()
    {
        transform.Rotate(transform.up, turningSpeed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider wormPickingUp)
    {
       WormPickuptest  theLuckyWorm =  wormPickingUp.gameObject.GetComponent<WormPickuptest>();
        theLuckyWorm.justPickedup(thisItemIs, valueOf, numberOf);

        print("Goodbye");
    }
}
