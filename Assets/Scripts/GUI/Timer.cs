using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

	public Text timerText;

	private float startTime;
	
	// Use this for initialization
	void Start ()
	{
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		timerText.text = getTimeString();
	}

	public float getCurrentTime()
	{
		return Time.time - startTime;
	}

	public string getTimeString()
	{
		var time = getCurrentTime();

		return String.Format("{0:D2}:{1:D2}", (int) time / 60, (int) time % 60);
	}
}
