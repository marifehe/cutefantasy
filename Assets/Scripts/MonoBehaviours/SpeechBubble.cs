using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour {

	public string textToShow;
	public Canvas theCanvas;

	// Use this for initialization
	void Start () {
		theCanvas.enabled = false;
		Transform textChild = theCanvas.transform.Find("Text");
		textChild.GetComponent<Text>().text = textToShow;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			theCanvas.enabled = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			theCanvas.enabled = true;
		}
	}


}
