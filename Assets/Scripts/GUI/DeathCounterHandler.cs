using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCounterHandler : MonoBehaviour
{
	private Text _deathCounter;
	// Use this for initialization
	void Start ()
	{
		_deathCounter = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateText();
	}


	void UpdateText()
	{
		var deaths = StatsManager.Instance.DeathCounter;
		var newText = deaths + (deaths == 1 ? " Death" : " Deaths");

		_deathCounter.text = newText;
	}
}
