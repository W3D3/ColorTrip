using Assets;
using UnityEngine;

public class TriggerController : MonoBehaviour
{

    public string TriggerMessage;
    public TextboxController StatusText;

	// Use this for initialization
	void Start ()
	{
	    
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Component c)
    {
        if (c.tag != "Player") return;

        StatusText.Show(TriggerMessage);
    }

    public void OnTriggerExit2D(Component c)
    {
        if (c.tag != "Player") return;

        StatusText.TriggerFadeOut();
    }
}
