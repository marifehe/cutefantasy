using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour, IIsUnlockedByItem {

	public GameObject targetObject;
	public Animator theAnimator;
	public float velocity = 3;

	public bool movementIsActive = false;

	void Start() {
		movementIsActive = false;
		theAnimator = GetComponent<Animator>();
	}

	void Update() {
		if (movementIsActive) {
			theAnimator.SetBool("Walking", true);
			Vector2 origin = new Vector2(transform.position.x, transform.position.y);
			Vector2 target = new Vector2(targetObject.transform.position.x,
				targetObject.transform.position.y);
			transform.position = Vector2.MoveTowards(origin, target, velocity * Time.deltaTime);
		} else {
			theAnimator.SetBool("Walking", false);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == targetObject.tag) {
			movementIsActive = false;
		}
	}

	public void ItemUsed() {
		movementIsActive = true;
	}
}
