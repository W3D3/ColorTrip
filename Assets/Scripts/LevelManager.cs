using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void SetupScene(int level)
	{
		Debug.Log("Scene loading: " + level);
		SceneManager.LoadScene("level" + level , LoadSceneMode.Single);
	}
	
	public void SetupSceneViaName(string level)
	{
		Debug.Log("Scene loading: " + level);
		SceneManager.LoadScene(level , LoadSceneMode.Single);
	}
}
