using UnityEngine;

public class MainMenuController : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject TutorialMenu;
    public GameObject LevelMenu;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (GamepadInput.Pause())
	    {
	        if (TutorialMenu.activeSelf || LevelMenu.activeSelf)
	        {
                GoToMainMenu();
	        }
	    }
	}

    public void GoToMainMenu()
    {
        TutorialMenu.SetActive(false);
        LevelMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void GoToTutorialMenu()
    {
        MainMenu.SetActive(false);
        TutorialMenu.SetActive(true);
    }

    public void GoToLevelMenu()
    {
        MainMenu.SetActive(false);
        LevelMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
