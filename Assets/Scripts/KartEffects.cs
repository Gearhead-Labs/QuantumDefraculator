using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartEffects : MonoBehaviour {

	//==( VARIABLES )=========================================================//
	Controller myController;
	ParticleSystem myParticleSystem;
	//==( FUNCTIONS )=========================================================//
	void Start ()
	{
		myController = gameObject.GetComponentInParent<Controller> ();
		myParticleSystem = gameObject.GetComponent<ParticleSystem> ();
	}

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
