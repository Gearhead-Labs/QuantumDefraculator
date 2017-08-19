using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartEffects : MonoBehaviour {

	Controller myController;
	ParticleSystem myParticleSystem;
	// Use this for initialization
	void Start ()
	{
		myController = gameObject.GetComponentInParent<Controller> ();
		myParticleSystem = gameObject.GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (myController.Propelling)
		{
			myParticleSystem.Play ();
		} else
		{
			myParticleSystem.Stop ();
		}
	}
}
