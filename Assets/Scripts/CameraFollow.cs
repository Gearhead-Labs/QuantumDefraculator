using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float lookSmooth = 0.09f;
	public Vector3 offsetFromTarget = new Vector3(0, 1, -3);
	public float xTilt = 15;

	Vector3 destination = Vector3.zero;
	Controller charController;
	float rotateVel = 0;
	// Use this for initialization
	void Start () {
		SetCameraTarget (target);
	}

	void SetCameraTarget(Transform t){
		target = t;

		if (target != null) {
			if (target.GetComponent<Controller> ()) {
				charController = target.GetComponent<Controller> ();
			} else {
				Debug.LogError ("Camera target has no controller");
			}
		}
		else { Debug.LogError ("Camera has no target"); }
	}

	// Update: once per frame, FixedUpdate: can be multiple per frame
	// LateUpdate is called after Update
	void LateUpdate () {
		//moving
		MoveToTarget();
		//rotating
		LookAtTarget();
	}
	void MoveToTarget() {
		destination = charController.TargetRotation * offsetFromTarget;
		destination += target.position;
		transform.position = destination;
	}

	void LookAtTarget() {
		float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);
		transform.rotation = Quaternion.Euler(transform.eulerAngles.x, eulerYAngle, 0);
	}
}

