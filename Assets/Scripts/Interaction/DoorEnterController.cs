using Assets.Scripts.Movement;
using UnityEngine;

namespace Assets.Scripts.Interaction
{
    public class DoorEnterController : MonoBehaviour
    {
        public GameObject LevelFinishedPanel;

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
		
        }

        public void OnTriggerEnter2D(Component c)
        {
            if (c.tag != "Player") return;
            
            LevelFinishedPanel.SetActive(true);
            GamepadInput.EnablePlayerControls = false;
            GamepadInput.EnableColorControls = false;
        }
    }
}
