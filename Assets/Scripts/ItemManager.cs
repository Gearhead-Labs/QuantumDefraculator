using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Keep count of the number of items: 12
public enum ItemType { 	Special, Stealy, IceT, Eyehole, FakeBox,
						Ants, Fart, Meeseeks, FleebJuice, Crystals,
						MortyJr, ScaryTerry }

public class ItemManager: MonoBehaviour
{
	public static ItemManager instance = null; 

	float itemCount = 12f;
	ItemType myItemType;


	void Awake ()
	{
		//Check if instance already exists
		if (instance == null)
		{
			//if not, set instance to this
			instance = this;
		}

		//If instance already exists and it's not this:
		else if (instance != this)
		{
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy (gameObject);    
		}

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}

	void Start ()
	{
		
	}

	void Update ()
	{
		

	}

	public ItemType RandomItem () {
		myItemType = (ItemType)Random.Range(0, itemCount);
		return myItemType;
	}
		
}
