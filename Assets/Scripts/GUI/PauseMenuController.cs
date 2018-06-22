using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Movement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{

    public float TimePlayed;
    public float StartTime;
    public int DeathCount;

    public Player Player;

    // UI

    public bool InPauseMenu;
    public GameObject PauseMenu;
    public Text TextDeathCount;
    public Text TextTimePlayed;

	// Use this for initialization
	void Start ()
	{
	    InPauseMenu = false;
	    TimePlayed = 0;
	    StartTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	    if (!InPauseMenu && GamepadInput.Pause())
	    {
            OpenPauseMenu();
	    } else if (InPauseMenu && GamepadInput.Pause())
	    {
            ContinueGame();
	    }
	}

    public void StopTime()
    {
        Time.timeScale = 0f;
        TimePlayed += Time.time - StartTime;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1f;
        StartTime = Time.time;
    }

    public void OpenPauseMenu()
    {
        InPauseMenu = true;
        StopTime();
        TextDeathCount.text = DeathCount.ToString();
        TextTimePlayed.text = GetPlayTimeFormatted();
        PauseMenu.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        InPauseMenu = false;
        ResumeTime();
        PauseMenu.SetActive(false);
    }

    private string GetPlayTimeFormatted()
    {
        var minutes = (int)(TimePlayed / 60);
        var seconds = (TimePlayed % 60);
        var hours = minutes / 60;
        minutes = minutes % 60;

        var time = string.Empty;

        if (hours > 0)
        {
            time = string.Format("{0:00}:", hours);
        }

        return time + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ContinueGame()
    {
        ClosePauseMenu();
    }

    public void RespawnAtCheckpoint()
    {
        ClosePauseMenu();
        Player.Respawn();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResumeTime();
    }

    public void GoToMainMenu()
    {
        // SceneManager.LoadScene(mainMenuScene);
        ResumeTime();
    }
}
