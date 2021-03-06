﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;
	
	private LevelManager levelManager; //Store a reference to our LevelManager which will set up the level.
	private SoundManager soundManager;
	public int level = -1; //set negative in order to just load no level :O (Herry)

    public ColorSet currentColorSet;
	
	//Awake is always called before any Start functions
	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);

		//Get a component reference to the attached BoardManager script
		levelManager = GetComponent<LevelManager>();
		soundManager = GetComponent<SoundManager>();

		//TODO Select randomly/based on lvl number
		currentColorSet = Colors.COLORSET_1;

		//Call the InitGame function to initialize the first level 
		InitGame();
	}

	//Initializes the game for each level.
	void InitGame()
	{
		//Call the SetupScene function of the BoardManager script, pass it current level number.
		if (levelManager != null && level >= 0)
		{
			levelManager.SetupScene(level);
		}
		else Debug.LogError("DU BIST 1 ID1OT!!!111!elfone^^^^2");
	}

	public void advanceLevel(int number)
	{
		levelManager.SetupScene(number);
	}
	
	public void advanceLevel(string levelName)
	{
		levelManager.SetupSceneViaName(levelName);
	}

	public void playJumpSound()
	{
		soundManager.jumpSound.Play();
	}
	
	public void deathIsEternal()
	{
		soundManager.deathSound.Play();
		StatsManager.Instance.CurrentStats().DeathCount++;
	}
	
	public void playDashSound()
	{
		soundManager.dashSound.Play();
	}
}