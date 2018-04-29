using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

	public Text timerText;
	
	// Update is called once per frame
	void Update ()
	{
		timerText.text = getTimeString();
	}


	public string getTimeString()
	{
		var time = StatsManager.Instance.TimeNeededWithCurrentTime;

		return String.Format("{0:D2}:{1:D2}", (int) time / 60, (int) time % 60);
	}
}
