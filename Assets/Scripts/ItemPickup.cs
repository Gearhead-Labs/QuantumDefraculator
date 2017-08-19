using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {

	Collider playerCollider;
	SpriteRenderer mySprite;
	float waitTime;

	void Start ()
	{
		mySprite = gameObject.GetComponentInChildren<SpriteRenderer> ();
		waitTime = 0f;
	}

	void Update ()
	{
		if (mySprite.enabled == false)
		{
			waitTime += 1f;	
			if (waitTime > 5f * Time.deltaTime)
			{
				mySprite.enabled = true;
				waitTime = 0f;
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Player"))
		{
			other.GetComponent<Controller> ().SzechuanMeter = 100f;
			mySprite.enabled = false;
		}
	}

}
