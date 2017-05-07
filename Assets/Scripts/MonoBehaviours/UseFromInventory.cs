using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseFromInventory : MonoBehaviour {

	// Key for activating the option to use an object from the inventory
	// This can be removed and be automatic when the user enters the trigger
	public KeyCode activateKey;

	private bool isActive;
	private Inventory theInventory;

	// Use this for initialization
	void Start () {
		theInventory = FindObjectOfType<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
		// TODO: commented from now (the user walking close by will
		// activate the inventory directly, no need to extra clicks)
		/*if(Input.GetKeyUp(activateKey)) {
			if(isActive) {
				// TODO: Show text to use an item from inventory
				print(">>>>>>>"  + title);
				theInventory.EnableUsingAnItem();
			}
		}*/
	}

	// Whenever player hits the trigger (it is enough close)
	// the item will be active
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			isActive = true;
			theInventory.EnableUsingAnItem();
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			isActive = false;
			theInventory.DisableUsingAnItem();
		}
	}
}
