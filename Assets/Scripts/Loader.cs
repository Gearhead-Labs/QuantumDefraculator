using UnityEngine;
using System.Collections;


public class Loader : MonoBehaviour 
{
	public GameObject itemManager;          //ItemManager prefab to instantiate.
	public GameObject raceManager;         //RaceManager prefab to instantiate.


	void Awake ()
	{
//		//Check if a ItemManager has already been assigned to static variable ItemManager.instance or if it's still null
//		if (itemManager.instance == null)
//
//			//Instantiate gameManager prefab
//			Instantiate(itemManager);
//
//		//Check if a RaceManager has already been assigned to static variable RaceManager.instance or if it's still null
//		if (raceManager.instance == null)
//
//			//Instantiate SoundManager prefab
//			Instantiate(raceManager);
	}
}