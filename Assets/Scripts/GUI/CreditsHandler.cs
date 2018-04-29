using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsHandler : MonoBehaviour
{
	private const string LB = "\r\n";

	public Text DeathCounterText;
	public Text TimeNeededText;
	public Text DetailedStats;

	// Use this for initialization
	void Start ()
	{
		
		StatsManager.Instance.PushLevel();		
		StatsManager.Instance.PushLevel();		
		StatsManager.Instance.PushLevel();		
		StatsManager.Instance.PushLevel();
		
		DeathCounterText.text = StatsManager.Instance.DeathCounter.ToString();
		TimeNeededText.text = StatsManager.GetTimeFormatted(StatsManager.Instance.TimeNeeded);
		DetailedStats.text = buildDetailedStats();
	}

	private string buildDetailedStats()
	{
		var stats = StatsManager.Instance.GetStats();

		var result = "";

		for (int i = 0; i < stats.Count; i++)
		{
			var level = stats[i];
			
			result += "Level " + (i + 1) + LB;

			result += "Time needed: " + StatsManager.GetTimeFormatted(level.TimeNeeded) + LB;
			result += "Deaths: " + level.DeathCount + LB;
			result += LB;
		}

		return result;
	}
}
