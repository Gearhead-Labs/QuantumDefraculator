using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleRenderer : MonoBehaviour {

	public Sprite Angle0;
	public Sprite Angle1;
	public Sprite Angle2;
	public Sprite Angle3;
	public Sprite Angle4;
	public Sprite Angle5;
	public Sprite Angle6;
	public Sprite Angle7;
	public Sprite Angle8;
	public Sprite Angle9;
	public Sprite Angle10;
	public Sprite Angle11;

	float ObjectAngle;
	float CameraAngle;

	// Update is called once per frame
	void Update ()
	{
		ObjectAngle = gameObject.transform.eulerAngles.y;
		CameraAngle = Camera.main.transform.eulerAngles.y;
		float AngleDiff = Mathf.RoundToInt ((ObjectAngle - CameraAngle) / 30);
		switch ((int)AngleDiff)
		{
			case 0:
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = Angle0;
				break;
			case 1:
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = Angle1;
				break;
			case 2:
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = Angle2;
				break;
			case 3:
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = Angle3;
				break;
			case 4:
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = Angle4;
				break;
			case 5:
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = Angle5;
				break;
			case 6:
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = Angle6;
				break;
			case -6:
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = Angle6;
				break;
			case -5:
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = Angle7;
				break;
			case -4:
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = Angle8;
				break;
			case -3:
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = Angle9;
				break;
			case -2:
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = Angle10;
				break;
			case -1:
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = Angle11;
				break;
			
		}
	} 
}
