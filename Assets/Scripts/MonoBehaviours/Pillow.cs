using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : MonoBehaviour, IIsUnlockedByItem {

	private bool displayPillow;

	void Start() {
		displayPillow = false;
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
	}

	void Update () {
		if (displayPillow) {
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
		}
	}

	public void ItemUsed() {
		print("Pillow is used!!");
		displayPillow = true;
	}
}
