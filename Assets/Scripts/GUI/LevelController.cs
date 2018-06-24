using Assets.Scripts.Movement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.GUI
{
    public class LevelController : MonoBehaviour
    {

        public float CurrentTimePlayed;
        public float TimePlayed;
        public float StartTime;

        public Player Player;
        
        // pause screen
        public bool InPauseMenu;
        public GameObject PauseMenu;
        public Text TextDeathCounterPause;
        public Text TextTimePlayedPause;

        // finished screen
        public bool InFinishedMenu;
        public GameObject FinishedMenu;
        public Text TextDeathCounterFinished;
        public Text TextTimePlayedFinished;

        // game hud
        public GameObject GameHud;
        public Text TextDeathCounterHud;
        public Text TextTimePlayedHud;

        public string NextLevelScene;
        public string MainMenuScene;

        // Use this for initialization
        void Start ()
        {
            InPauseMenu = false;
            InFinishedMenu = false;
            TimePlayed = 0;
            CurrentTimePlayed = 0;
            StartTime = Time.time;

            Cursor.visible = false;
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

            TextDeathCounterHud.text = Player.Deaths.ToString();
            CurrentTimePlayed = Time.time - StartTime;
            TextTimePlayedHud.text = GetPlayTimeFormatted(TimePlayed + CurrentTimePlayed);
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
            TextDeathCounterFinished.text = Player.Deaths.ToString();
            TextTimePlayedFinished.text = GetPlayTimeFormatted(TimePlayed);
            GameHud.SetActive(false);
            PauseMenu.SetActive(false);
            FinishedMenu.SetActive(true);
        }

        public void OpenPauseMenu()
        {
            InPauseMenu = true;
            InFinishedMenu = false;
            StopTime();
            TextDeathCounterPause.text = Player.Deaths.ToString();
            TextTimePlayedPause.text = GetPlayTimeFormatted(TimePlayed);
            GameHud.SetActive(false);
            FinishedMenu.SetActive(false);
            PauseMenu.SetActive(true);
        }

        public void ClosePauseMenu()
        {
            InPauseMenu = false;
            ResumeTime();
            PauseMenu.SetActive(false);
            GameHud.SetActive(true);
        }

        private string GetPlayTimeFormatted(float targetTime)
        {
            var minutes = (int)(targetTime / 60);
            var seconds = (targetTime % 60);
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

            ResumeTime();
            SceneManager.LoadScene(NextLevelScene, LoadSceneMode.Single);
        }

        public void RestartLevel()
        {
            ResumeTime();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }

        public void GoToMainMenu()
        {
            ResumeTime();
            SceneManager.LoadScene(MainMenuScene, LoadSceneMode.Single);
        }
    }
}
