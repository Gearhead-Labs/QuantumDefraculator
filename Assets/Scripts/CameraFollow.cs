using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum KartState { Drive, Drift }

public class CameraFollow : MonoBehaviour {

	//==( VARIABLES )=========================================================//
	// Public
	public Transform target;
	public float lookSmooth = 0.09f;
	public Vector3 offsetFromTarget = new Vector3(0, 1, -3);
	public float xTilt = 15;
	// Private
	float velThreshold; // at a speed below this, the camera jitters
	KartState kartState;
	float offsetPlus, targetOffsetPlus;
	Vector3 destination = Vector3.zero;
	Controller charController;
	float rotateVel = 0;

	//==( FUNCTIONS )=========================================================//
	void Start ()
	{
		kartState = KartState.Drive;
		offsetPlus = 1f;
		targetOffsetPlus = 1;
		velThreshold = 40f;
		SetCameraTarget (target);
	}

	void SetCameraTarget(Transform t)
	{
		target = t;

		if (target != null)
		{
			if (target.GetComponent<Controller> ())
			{
				charController = target.GetComponent<Controller> ();
			} else
			{
				Debug.LogError ("Camera target has no controller");
			}
		}
		else { Debug.LogError ("Camera has no target"); }
	}

	// LateUpdate instead of Update which will make camera jitter
	void LateUpdate ()
	{

		CheckState ();
	
		MoveToTarget();

		LookAtTarget();
	}


	void CheckState()
	{
		if (charController.DriftInput > 0)
		{
			kartState = KartState.Drift;
		} else
		{
			kartState = KartState.Drive;
		}
	}

	void MoveToTarget()
	{
		
		switch (kartState)
		{
			case KartState.Drive:
				
				break;
			case KartState.Drift:
				
				break;
		}
		if (charController.ActualSpeed > velThreshold)
		{
			targetOffsetPlus = 1 + charController.ActualSpeed / 100f;
		}
		if (offsetPlus < targetOffsetPlus)
		{
			offsetPlus += 0.02f;
		}
		else if (offsetPlus > targetOffsetPlus)
		{
			offsetPlus -= 0.02f;	
		}

		destination = charController.TargetRotation * offsetFromTarget * offsetPlus;
		destination += target.position;
		transform.position = destination;

	}

	void LookAtTarget()
	{
		float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);
		transform.rotation = Quaternion.Euler(transform.eulerAngles.x, eulerYAngle, 0);
	}
}

