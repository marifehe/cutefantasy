using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public Sprite sprite;


	private bool isCollectable;
	private Inventory theInventory;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			
		};
		
	}

	// Whenever player collides (it is enough close)
	// the item will be collectable
	void OnCollisionEnter2D(Collision2D other) {
		// Collision is a moment in time when collision happen, this is why
		// is necessary to access the gameObject from the collision object
		if (other.gameObject.tag == "Player") {
			isCollectable = true;
		}
	}

	void OnCollisionExit2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			isCollectable = false;
		}
	}

	public bool IsCollectable() {
		return isCollectable;
	}
}
