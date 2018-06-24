using Assets.Scripts.Movement;
using UnityEngine;

public class ZeroGravityController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Component c)
    {
        if (c.tag != "Player") return;

        var player = c.GetComponent<Player>();
        player.ZeroGravity = true;
    }

    private void OnTriggerExit2D(Component c)
    {
        if (c.tag != "Player") return;

        var player = c.GetComponent<Player>();
        player.ZeroGravity = false;
    }
}
