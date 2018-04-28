using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;
	
	private LevelManager levelManager; //Store a reference to our BoardManager which will set up the level.

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

		//TODO Select randomly/based on lvl number
		currentColorSet = Colors.COLORSET_1;

		//Call the InitGame function to initialize the first level 
		InitGame();
	}

	//Initializes the game for each level.
	void InitGame()
	{
		//Call the SetupScene function of the BoardManager script, pass it current level number.
		if(levelManager != null && level >= 0) levelManager.SetupScene(level);
		else Debug.Log("DEBUG MODE!!!!!!!");
	}

	public void advanceLevel()
	{
		Debug.Log(level);
		levelManager.SetupScene(level++);
	}
}