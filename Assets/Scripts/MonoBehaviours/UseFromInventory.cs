using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseFromInventory : MonoBehaviour {

	// Key for activating the option to use an object from the inventory
	// This can be removed and be automatic when the user enters the trigger
	public KeyCode activateKey;
	public string title = "You can use an item from the inventory now!";


	private bool isActive;
	private Inventory theInventory;

	// Use this for initialization
	void Start () {
		theInventory = FindObjectOfType<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(activateKey)) {
			if(isActive) {
				// TODO: Show text to use an item from inventory
				print(">>>>>>>"  + title);
				theInventory.EnableUsingAnItem();
			}
		}
	}

	// Whenever player hits the trigger (it is enough close)
	// the item will be active
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			isActive = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			// TODO: Hide text to use an item from inventory
			isActive = false;
			theInventory.DisableUsingAnItem();
		}
	}
}
