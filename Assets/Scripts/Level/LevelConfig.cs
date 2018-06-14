using UnityEngine;

namespace Assets.Scripts.Level
{
    public class LevelConfig : MonoBehaviour
    {
        public LevelTheme LevelTheme;

        private LevelColor _levelColor;

        void Start ()
        {
            _levelColor = ColorFactory.FromTheme(LevelTheme);
        }
    }
}
