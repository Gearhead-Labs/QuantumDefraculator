using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SzechuanMeter : MonoBehaviour {
	Controller myController;
	float PlayerSzechuan;

	void Start () {
		myController = GameObject.FindWithTag ("Player").GetComponent<Controller> ();
	}
	void Update () {
		PlayerSzechuan = myController.SzechuanMeter;

		gameObject.GetComponent<Text>().text = "Szechuan: " + PlayerSzechuan.ToString("#0.00");
	}
}
