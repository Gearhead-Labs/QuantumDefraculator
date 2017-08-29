using System.Collections;
using UnityEngine;

public class Controller : MonoBehaviour {

	//==( VARIABLES )=========================================================//
	Rigidbody rBody;
	BoxCollider2D groundCollider;

	float currentForwardInput, lastForwardInput, turnInput, friction;
	float szechuanForce;
	float forwardVel;
	Vector3 driftVector;
	bool onTrack;
	float propel;

	Quaternion targetRotation;
	public Quaternion TargetRotation {
		get { return targetRotation; }
	}

	// Public vars
	// For adjustments
	public float InputDelay = 0.1f;
	public float MaxVel = 15f;
	public float RotateVel = 100f;
	public float AccelRate = 0.7f;
	public float DriftFactor = 2f;

	// For other scripts
	public float ActualSpeed; // for Speedometer
	public float SzechuanMeter = 0f; // for Szechuan Meter
	public bool Propelling; // for CameraFollow
	public float DriftInput, LastDriftInput; // for CameraFollow


	void Start () {
		// locate player
		targetRotation = transform.rotation;
		if (GetComponent<Rigidbody> ()) {
			rBody = GetComponent<Rigidbody> ();
		} else {
			Debug.LogError ("No rigidbody");
		}

		currentForwardInput = lastForwardInput = turnInput = forwardVel = 0;
		szechuanForce = friction = 1f;
		groundCollider = gameObject.GetComponentInChildren<BoxCollider2D> ();
	}
		
	void Update () {
		GetInput ();
		CheckTerrain ();
		CheckSzechuan ();
		Move ();
		Turn ();
	}

	//==( FUNCTIONS )==============================================================//
	void GetInput() {
		currentForwardInput = Input.GetAxis ("Vertical");
		turnInput = Input.GetAxis ("Horizontal");
		DriftInput = Input.GetAxis ("Drift");
		propel = Input.GetAxis ("Propel");

	}

	void Move() {
		// Drifting
		// When drift down
		if ((DriftInput > LastDriftInput) || (DriftInput == 1))
		{
			if (LastDriftInput == 0) // at keydown, freeze forward vector
			{
				driftVector = transform.forward;
			}

		} else if ((DriftInput < LastDriftInput) || (DriftInput == 0)) // update forward continuously
		{
			driftVector = transform.forward;
		}

		// Szechuan boosting - see CheckSzechuan function
		if (Propelling)
		{
			if (szechuanForce < 1.5f)	{ szechuanForce += 0.05f; 	}
			else 						{ szechuanForce = 1.5f;		}
		}
		else
		{
			if (szechuanForce > 1f) 	{ szechuanForce -= 0.01f;	}
			else 						{ szechuanForce = 1f; 		}
		}

		if ((currentForwardInput > lastForwardInput) || (currentForwardInput == 1))
		{
			if (forwardVel < MaxVel)
			{
				forwardVel += AccelRate;
			}
			
		} else if ((currentForwardInput < lastForwardInput) || (currentForwardInput == 0))
		{
			 // coming to a stop
			if (forwardVel > 0f)
			{
				forwardVel -= AccelRate / 2;	
			} else
			{
				forwardVel = 0f;
				rBody.velocity = Vector3.zero;
			}
		}

		rBody.velocity = driftVector * forwardVel * szechuanForce
			* friction * (1 + Mathf.Pow (currentForwardInput, 2));

		lastForwardInput = currentForwardInput;
		LastDriftInput = DriftInput;


		ActualSpeed = rBody.velocity.magnitude;

	}



    void Turn() {
//		if (rBody.velocity.magnitude > 4f)
//        { 
		targetRotation *= Quaternion.AngleAxis (RotateVel * turnInput * forwardVel/MaxVel * Time.deltaTime, Vector3.up);   

		transform.rotation = targetRotation;
	}



	void CheckTerrain ()
	{
		
		onTrack = groundCollider.IsTouching (GameObject.FindWithTag("Track").GetComponentInChildren<PolygonCollider2D>());
			
		if (onTrack) {
			print ("I'm On Track");
		}
	}

	void CheckSzechuan ()
	{
//		float szechuanFactor = 1f;
			
		if ((propel > InputDelay) && (SzechuanMeter > 0))
		{
			Propelling = true;
			SzechuanMeter -= 1f;
		} else {
			Propelling = false;
		}
		// szechuanForce *= szechuanFactor;
		// this is for future (hold boost for long = boost harder)
	
		
			
	}
}

