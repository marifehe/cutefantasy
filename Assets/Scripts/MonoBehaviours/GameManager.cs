using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UseItem(Item itemUsed) {
		// When an item is used, it unlocks an action for the specified
		// tag
		if (itemUsed.tagThatUnlocks != null) {
			print(">>>> tag unlocked: " + itemUsed.tagThatUnlocks);
         	GameObject[] gos = GameObject.FindGameObjectsWithTag(itemUsed.tagThatUnlocks); 
 
         	for (var i = 0; i< gos.Length; i++) {
         		gos[i].SendMessage("ItemUsed");
         	}
		}
	}
}
