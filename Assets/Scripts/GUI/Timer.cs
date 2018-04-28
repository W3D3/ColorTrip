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
		float t = Time.time - startTime;

		string minutes = padZeroes(((int) t / 60).ToString(), 2);
		string seconds = padZeroes(((int) t % 60).ToString(), 2);
		timerText.text = minutes + ":" + seconds;

	}

	private string padZeroes(String numberString, int length)
	{
		for (int i = length - numberString.Length; i < length; i++)
		{
			numberString = "0" + numberString;
		}

		return numberString;
	}
}
