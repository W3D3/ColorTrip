using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCounterHandler : MonoBehaviour
{
	private Text deathCounter;
	// Use this for initialization
	void Start ()
	{
		deathCounter = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateText();
		
		Debug.Log("Test");

	}


	void UpdateText()
	{
		var deaths = GameManager.instance.DeathCounter;
		var newText = deaths + (deaths == 1 ? " Death" : " Deaths");

		
		
		deathCounter.text = newText;
	}
}
