using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollide: MonoBehaviour {

	//==( VARIABLES )=========================================================//
	Collider playerCollider;
	SpriteRenderer mySprite;
	ItemType item;

	float oscillationAmplitude = 0.02f;
	float oscillationSpeed = 2f;

	public float waitTime;

	//==( FUNCTIONS )=========================================================//

	void Start ()
	{
		mySprite = gameObject.GetComponent<SpriteRenderer> ();
		waitTime = 0f;

	}

	void Update ()
	{
		// Oscillating in y axis
		float height = mySprite.transform.position.y;
		height += oscillationAmplitude * Mathf.Sin (Time.time * oscillationSpeed); //sine function
		mySprite.transform.position = new Vector3 (mySprite.transform.position.x, height, mySprite.transform.position.z);

		if (mySprite.color == Color.clear)
		{
			waitTime += 1f;	

			if (waitTime > 50f)
			{
				mySprite.color = Color.white;
				gameObject.GetComponent<SphereCollider> ().isTrigger = true;

				waitTime = 0f;
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Player"))
		{
			item = gameObject.GetComponentInParent<ItemManager> ().RandomItem();

			//other.;
			mySprite.color = Color.clear;
			gameObject.GetComponent<SphereCollider> ().isTrigger = false;
			LightFlash ();
		}
	}

	void LightFlash () {

	}

}
