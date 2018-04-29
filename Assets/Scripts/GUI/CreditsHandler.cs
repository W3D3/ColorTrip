using UnityEngine;
using UnityEngine.UI;

public class CreditsHandler : MonoBehaviour
{

	public Text DeathCounterText;
	public Text TimeNeededText;

	// Use this for initialization
	void Start ()
	{
		DeathCounterText.text = StatsManager.Instance.DeathCounter.ToString();
		TimeNeededText.text = StatsManager.GetTimeFormatted(StatsManager.Instance.TimeNeeded);
	}
}
