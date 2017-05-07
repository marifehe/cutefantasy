using UnityEngine;
using System;

public class Item : MonoBehaviour {

	public Sprite sprite;
	public KeyCode pickUpKey;
	public string tagThatUnlocks;

	private bool isCollectable;
	private Inventory theInventory;

	// Use this for initialization
	void Start () {
		theInventory = FindObjectOfType<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(pickUpKey)) {
			if(isCollectable) {
				theInventory.AddItem(this);
				gameObject.SetActive(false);
			}
		}
	}

	// Whenever player hits the trigger (it is enough close)
	// the item will be collectable
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			print(">>>>>>> Press key to collect this item");
			isCollectable = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			isCollectable = false;
		}
	}
}
