using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{

	void OnCollisionEnter (Collision collisionInfo)
	{
		Debug.Log ("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
		Debug.Log ("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
		Debug.Log ("Their relative velocity is " + collisionInfo.relativeVelocity);
	}

	void OnCollisionStay (Collision collisionInfo)
	{
		Debug.Log (gameObject.name + " and " + collisionInfo.collider.name + " are still colliding");
	}

	void OnCollisionExit (Collision collisionInfo)
	{
		Debug.Log (gameObject.name + " and " + collisionInfo.collider.name + " are no longer colliding");
	}

}