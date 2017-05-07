using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBehaviour : MonoBehaviour {

	private bool isFalling;
	private Animator theAnimator;

	// Use this for initialization
	void Start () {
		isFalling = false;
		theAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionExit2D(Collision2D collision) {
		if (collision.gameObject.tag == "HousePlatform") {
			theAnimator.SetBool("Falling", true);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Ground") {
			theAnimator.SetBool("Falling", false);
			theAnimator.SetBool("Walking", true);
		}
	}
}
