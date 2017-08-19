using System.Collections;
using UnityEngine;

public class Controller : MonoBehaviour {


	Rigidbody rBody;
	BoxCollider2D groundCollider;

	float currentForwardInput, lastForwardInput, turnInput, friction;
	float szechuanForce;
	float forwardVel;
	Vector3 driftVector;
	bool onTrack, refill, propel;

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

	void GetInput() {
		currentForwardInput = Input.GetAxis ("Vertical");
		turnInput = Input.GetAxis ("Horizontal");
		DriftInput = Input.GetAxis ("Drift");
		propel = Input.GetKey (KeyCode.C);
		refill = Input.GetKey (KeyCode.A);

	}

		

	void Update () {
		GetInput ();
		CheckTerrain ();
		CheckSzechuan ();
		Move ();
		Turn ();

	}

	void FixedUpdate() {
		

	}



	void Move() {
		// Drifting
		if ((DriftInput > 0) && (LastDriftInput == 0)) // freeze forward at keydown
		{
			driftVector = transform.forward;
		} else if ((DriftInput < LastDriftInput) || (DriftInput == 0)) // update forward if key released
		{
			driftVector = transform.forward;
		}

		// Szechuan boosting - see CheckSzechuan function
		if (Propelling)
		{
			if (szechuanForce < 1.5f)
			{
				szechuanForce += 0.01f;
			}
		} else
		{
			if (szechuanForce > 1f)
			{
				szechuanForce -= 0.1f;
			}
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
		transform.forward = driftVector;
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
		} else if (!onTrack) {
			print ("where am i");
		}
	}

	void CheckSzechuan ()
	{
//		float szechuanFactor = 1f;
		if (refill) // temporary button before we have the actual item
		{
			SzechuanMeter = 100f;
		}
			
		if ((propel) && (SzechuanMeter > 0))
		{
			Propelling = true;
			SzechuanMeter -= 1f;
		} else {
			Propelling = false;
		}
//		szechuanForce *= szechuanFactor; // this Factor is for future
	
		
			
	}
}

