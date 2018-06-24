using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets.Scripts.Scoring
{
    public class ScoreController : MonoBehaviour
    {
        public static List<ScoreData> ScoreData;

        public static ScoreData GetScoreForLevel(string levelName)
        {
            var scores = GetScores();
            return scores.FirstOrDefault(x => x.LevelName == levelName);
        }

        public static List<ScoreData> GetScores()
        {
            if (ScoreData != null) return ScoreData;

            var path = Path.Combine(Application.persistentDataPath, "scores.dat");
            if (!File.Exists(path)) return new List<ScoreData>();

            List<ScoreData> data;
            var formatter = new BinaryFormatter();
            using (var file = File.Open(path, FileMode.Open))
            {
                data = (List<ScoreData>) formatter.Deserialize(file);
            }

            return data;
        }

        public static bool UpdateScore(string levelName, int deaths, float timePlayed)
        {
            var scores = GetScores();
            var score = scores.FirstOrDefault(x => x.LevelName == levelName);

            if (score != null)
            {

                if (score.Deaths < deaths) return false;
                if (score.Deaths == deaths && score.TimePlayed < timePlayed) return false;
            }
            else
            {
                score = new ScoreData {LevelName = levelName};
                scores.Add(score);
            }

            // update only if less deaths, or equal deaths and less time
            score.Deaths = deaths;
            score.TimePlayed = timePlayed;

            var formatter = new BinaryFormatter();
            var path = Path.Combine(Application.persistentDataPath, "scores.dat");

            using (var file = File.Create(path))
            {
                formatter.Serialize(file, scores);
            }

            ScoreData = scores;

            return true;
        }

        public static void ResetScores()
        {
            var path = Path.Combine(Application.persistentDataPath, "scores.dat");
            if (!File.Exists(path)) return;

            File.Delete(path);
        }
    }
}
