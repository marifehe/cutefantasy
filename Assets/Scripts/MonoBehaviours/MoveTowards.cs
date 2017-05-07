using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour, IIsUnlockedByItem {

	public GameObject targetObject;
	public Animator theAnimator;
	public float velocity = 3;

	public bool facingLeft = false;

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
			// If the target girl is on the left, flip the origin girl since
			// otherwise it will be facing the wrong direction
			if (target.x < origin.x) {
				if (!facingLeft) {
					facingLeft = true;
					Flip();
				}
			}
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

	private void Flip() {
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
