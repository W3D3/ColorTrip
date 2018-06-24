using Assets.Scripts.Movement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.GUI
{
    public class LevelController : MonoBehaviour
    {

        public float TimePlayed;
        public float StartTime;

        public Player Player;

        // UI

        public bool InPauseMenu;
        public bool InFinishedMenu;
        public GameObject PauseMenu;
        public GameObject FinishedMenu;
        public Text TextDeathCounterInPause;
        public Text TextTimePlayedInPause;
        public Text TextDeathCounterInFinished;
        public Text TextTimePlayedInFinished;
        public string NextLevelScene;
        public string MainMenuScene;

        // Use this for initialization
        void Start ()
        {
            InPauseMenu = false;
            InFinishedMenu = false;
            TimePlayed = 0;
            StartTime = Time.time;
        }
	
        // Update is called once per frame
        void Update ()
        {
            if (InFinishedMenu) return;

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

        public void OpenFinishedMenu()
        {
            InFinishedMenu = true;
            InPauseMenu = false;
            StopTime();
            TextDeathCounterInFinished.text = Player.Deaths.ToString();
            TextTimePlayedInFinished.text = GetPlayTimeFormatted();
            PauseMenu.SetActive(false);
            FinishedMenu.SetActive(true);
        }

        public void OpenPauseMenu()
        {
            InPauseMenu = true;
            InFinishedMenu = false;
            StopTime();
            TextDeathCounterInPause.text = Player.Deaths.ToString();
            TextTimePlayedInPause.text = GetPlayTimeFormatted();
            FinishedMenu.SetActive(false);
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

        public void LoadNextLevel()
        {
            if (string.IsNullOrEmpty(NextLevelScene))
            {
                GoToMainMenu();
                return;
            }

            SceneManager.LoadScene(NextLevelScene);
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            ResumeTime();
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene(MainMenuScene);
        }
    }
}
