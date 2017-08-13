using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Billboard : MonoBehaviour
{

	void LateUpdate() 
	{
		transform.forward = Camera.main.transform.forward;
	}
}