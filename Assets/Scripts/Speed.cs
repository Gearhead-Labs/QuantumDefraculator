using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speed : MonoBehaviour {
	Controller myController;
	float PlayerSpeed;

	void Start () {
		myController = GameObject.FindWithTag ("Player").GetComponent<Controller> ();
	}
	void Update () {
		PlayerSpeed = myController.ActualSpeed;
//		print (PlayerSpeed);
		gameObject.GetComponent<Text>().text = "Speed: " + PlayerSpeed.ToString("#0.00");
	}
}
