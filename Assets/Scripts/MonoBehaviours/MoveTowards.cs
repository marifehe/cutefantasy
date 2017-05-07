using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour, IIsUnlockedByItem {

	public GameObject targetObject;
	public float velocity = 3;

	private bool movementIsActive;

	void Start() {
		movementIsActive = false;
	}

	void Update() {
		if (movementIsActive) {
			Vector2 origin = new Vector2(transform.position.x, transform.position.y);
			Vector2 target = new Vector2(targetObject.transform.position.x,
				targetObject.transform.position.y);
			transform.position = Vector2.MoveTowards(origin, target, velocity * Time.deltaTime);
		}
	}

	public void ItemUsed() {
		movementIsActive = true;
	}
}
