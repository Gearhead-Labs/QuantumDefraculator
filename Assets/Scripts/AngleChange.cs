using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enum SpriteType { kart_cruiser_00, kart_cruiser_01, kart_cruiser_02, kart_cruiser_03, kart_cruiser_4,
//	kart_cruiser_05, kart_cruiser_06, kart_cruiser_07, kart_cruiser_08, kart_cruiser_09,
//	kart_cruiser_10, kart_cruiser_11 }

public class AngleChange : MonoBehaviour {

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

	float ParentAngle;
	float CameraAngle;

	// Update is called once per frame
	void Update ()
	{
		ParentAngle = gameObject.transform.parent.eulerAngles.y; // 0 to 360 on kart
		CameraAngle = Camera.main.transform.eulerAngles.y; // 0 to 360 on camera

		float RawAngle = 360 - CameraAngle + ParentAngle; 
//		print(RawAngle);
		RenderAngles(RawAngle);

	} 

	void RenderAngles (float RawAngle) {
		// TO FIX: Perspective view makes far-away objects turn even when only camera turns.
		float AngleNumber;
		if (RawAngle >= 165 && RawAngle <= 195) {
			AngleNumber = 6;
		} else if (RawAngle >= -25 && RawAngle <= 25) {
			AngleNumber = 0;
		} else {
			AngleNumber = Mathf.RoundToInt(RawAngle/30);
		}
		switch ((int)AngleNumber)
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
			case 7:
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = Angle7;
				break;
			case 8:
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = Angle8;
				break;
			case 9:
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = Angle9;
				break;
			case 10:
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = Angle10;
				break;
			case 11:
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = Angle11;
				break;
			case 12:
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = Angle0;
				break;
		}
	}
}
