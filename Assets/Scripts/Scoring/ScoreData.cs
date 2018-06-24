using System;

namespace Assets.Scripts.Scoring
{
    [Serializable]
    public class ScoreData {

        public string LevelName { get; set; }
        public int Deaths { get; set; }
        public float TimePlayed { get; set; }
    }
}
