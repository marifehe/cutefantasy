using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubbleOnItemUsed : MonoBehaviour, IIsUnlockedByItem {

	public string textToShow;
	public Canvas theCanvas;

	private bool showCanvas = false;


	// Use this for initialization
	void Start () {
		showCanvas = false;
		theCanvas.enabled = showCanvas;
		Transform textChild = theCanvas.transform.Find("Text");
		textChild.GetComponent<Text>().text = textToShow;
	}

	void Update() {
		if(showCanvas) {
			theCanvas.enabled = true;
		}
	}

	public void ItemUsed() {
		showCanvas = true;
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			showCanvas = false;
			theCanvas.enabled = showCanvas;
		}
	}
}
