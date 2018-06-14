using UnityEngine;

namespace Assets.Scripts.Level
{
    public class LevelColor
    {
        public Color32 Player;
        public Color32 Color1;
        public Color32 Color2;
        public Color32 ColorMixed;

        public LevelColor()
        {
            Player = ColorFactory.Black;
            Color1 = ColorFactory.Crimson;
            Color2 = ColorFactory.RoyalBlue;
            ColorMixed = ColorFactory.Purple;
        }

        public LevelColor(Color32 color1, Color32 color2) : this()
        {
            Color1 = color1;
            Color2 = color2;
            ColorMixed = Color32.LerpUnclamped(color1, color2, 0.5f);
        }
    }
}
