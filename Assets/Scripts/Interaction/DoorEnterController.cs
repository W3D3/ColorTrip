using Assets.Scripts.GUI;
using UnityEngine;

namespace Assets.Scripts.Interaction
{
    public class DoorEnterController : MonoBehaviour
    {
        public LevelController LevelController;

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
		
        }

        public void OnTriggerEnter2D(Component c)
        {
            if (c.tag != "Player") return;
            
            LevelController.OpenFinishedMenu();
        }
    }
}
