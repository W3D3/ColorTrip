using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatsManager {
	public static readonly StatsManager Instance = new StatsManager();
	public class LevelStats
	{
		public int DeathCount;
		public float TimeNeeded;

		public override string ToString()
		{
			return DeathCount + " : " + TimeNeeded;
		}
	}

	public LevelStats CurrentStats()
	{
		return _levelStats[_levelStats.Count - 1];
	}

	private float _levelStartTime = Time.time;
	
	private readonly List<LevelStats> _levelStats = new List<LevelStats> {new LevelStats()};
	
	private StatsManager() {}

	public int DeathCounter
	{
		get { return _levelStats.Sum(ls => ls.DeathCount); }
	}

	public float TimeNeededWithCurrentTime
	{
		get { return TimeNeeded + Time.time - _levelStartTime; }
	}

	public float TimeNeeded
	{
		get { return _levelStats.Sum(ls => ls.TimeNeeded); }
	}

	public void PushLevel()
	{		
		var timeDiff = Time.time - _levelStartTime;
		
		// Fix Advance error: nobody can solve a level within one second
		if (timeDiff < 1) return;

		// Set current time
		CurrentStats().TimeNeeded = timeDiff;
		
		// Reset timer
		_levelStartTime = Time.time;
		_levelStats.Add(new LevelStats());

		string errors = "";
		_levelStats.ForEach(x => { errors += x + " \r\n"; });
		Debug.LogError(errors);
	}

	public List<LevelStats> Stats
	{
		get { return new List<LevelStats>(_levelStats); }
	}

	public static string GetTimeFormatted(float time)
	{
		var minutes = (int) (time / 60);
		var seconds = (time % 60);
		var hours = minutes / 60;
		minutes = minutes % 60;

		string formattedTime = "";

		if (hours > 0)
		{
			formattedTime += hours + "h ";
		}

		if (minutes > 0 || formattedTime != "")
		{
			formattedTime += String.Format("{0:D2}m ", minutes);
		}

		if (seconds > 0 || formattedTime != "")
		{
			formattedTime += String.Format("{0:F3}s", seconds);
		}

		return formattedTime;
		
	}
}
