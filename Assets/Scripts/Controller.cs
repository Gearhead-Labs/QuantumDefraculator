using System.Collections;
using UnityEngine;

public class Controller : MonoBehaviour {

	Rigidbody rBody;

	float currentForwardInput, lastForwardInput, turnInput;
	Vector3 driftVector;
	bool driftStart, drift;
	Quaternion targetRotation;
	public Quaternion TargetRotation {
		get { return targetRotation; }
	}


	public float inputDelay = 0.1f;
	public float maxVel = 35f;
	public float rotateVel = 100f;
	public float accelRate = 0.7f;


	float forwardVel = 0f;


	void Start () {
		// locate player
		targetRotation = transform.rotation;
		if (GetComponent<Rigidbody> ()) {
			rBody = GetComponent<Rigidbody> ();
		} else {
			Debug.LogError ("No rigidbody");
		}
		currentForwardInput = lastForwardInput = turnInput = 0;
	}

	void GetInput() {
		currentForwardInput = Input.GetAxis ("Vertical");
		turnInput = Input.GetAxis ("Horizontal");
		driftStart = Input.GetKeyDown (KeyCode.Z);
		drift = Input.GetKey (KeyCode.Z);
	}

		

	void Update () {
		GetInput ();
		Move ();
		Turn ();
		LockYAxis ();

	}

	void FixedUpdate() {
		

	}



	void Move() {
		if (driftStart) {
			driftVector = transform.forward;
//			
		}
		if ((currentForwardInput > lastForwardInput) || (currentForwardInput == 1)) {
			if (forwardVel < maxVel) {
				forwardVel += accelRate;
			}

			if (drift) {
				rBody.velocity = driftVector * (1 + Mathf.Pow (currentForwardInput, 2)) * forwardVel;
			} else {
				rBody.velocity = transform.forward * (1 + Mathf.Pow (currentForwardInput, 2)) * forwardVel;
			}
			print ("go go");
		} else if ((currentForwardInput < lastForwardInput) || (currentForwardInput == 0)) {
			 // coming to a stop
			if (forwardVel > 0f) {
				forwardVel -= accelRate;	
				if (drift) {
					rBody.velocity = driftVector * forwardVel * 2f;
				} else {
					rBody.velocity = transform.forward * forwardVel * 2f;
				}
				print ("stopping");
			} else {
				forwardVel = 0f;
				rBody.velocity = Vector3.zero;
			}

		}
		lastForwardInput = currentForwardInput;
	}



    void Turn() {
//		if (rBody.velocity.magnitude > 4f)
//        { 
		targetRotation *= Quaternion.AngleAxis (rotateVel * turnInput * forwardVel/maxVel * Time.deltaTime, Vector3.up);   

		transform.rotation = targetRotation;
	}

	void LockYAxis () // Make sure the karts don't levitate
	{
		Vector3 pos = transform.position;
		pos.y = 1f;
		transform.position = pos;

	}

}

