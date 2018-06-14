using UnityEngine;

namespace Assets.Scripts.Level
{
    public static class ColorFactory
    {
        public static LevelColor FromTheme(LevelTheme levelTheme)
        {
            LevelColor level;

            switch (levelTheme)
            {
                case LevelTheme.Default:
                    level = new LevelColor();
                    break;
                case LevelTheme.Rust:
                    level = new LevelColor
                    {
                        Color1 = Coral,
                        Color2 = Sienna,
                        ColorMixed = Brown
                    };
                    break;
                case LevelTheme.Winter:
                    level = new LevelColor
                    {
                        Color1 = CornflowerBlue,
                        Color2 = SpringGreen,
                        ColorMixed = HotPink
                    };
                    break;
                case LevelTheme.Mixed:
                    level = new LevelColor(Yellow, DodgerBlue);
                    break;
                default:
                    level = new LevelColor();
                    break;

            }

            return level;
        }

        public static Color32 Transparent { get { return new Color32(255, 255, 255, 0); } }
        public static Color32 AliceBlue { get { return new Color32(240, 248, 255, 255); } }
        public static Color32 AntiqueWhite { get { return new Color32(250, 235, 215, 255); } }
        public static Color32 Aqua { get { return new Color32(0, 255, 255, 255); } }
        public static Color32 Aquamarine { get { return new Color32(127, 255, 212, 255); } }
        public static Color32 Azure { get { return new Color32(240, 255, 255, 255); } }
        public static Color32 Beige { get { return new Color32(245, 245, 220, 255); } }
        public static Color32 Bisque { get { return new Color32(255, 228, 196, 255); } }
        public static Color32 Black { get { return new Color32(0, 0, 0, 255); } }
        public static Color32 BlanchedAlmond { get { return new Color32(255, 235, 205, 255); } }
        public static Color32 Blue { get { return new Color32(0, 0, 255, 255); } }
        public static Color32 BlueViolet { get { return new Color32(138, 43, 226, 255); } }
        public static Color32 Brown { get { return new Color32(165, 42, 42, 255); } }
        public static Color32 BurlyWood { get { return new Color32(222, 184, 135, 255); } }
        public static Color32 CadetBlue { get { return new Color32(95, 158, 160, 255); } }
        public static Color32 Chartreuse { get { return new Color32(127, 255, 0, 255); } }
        public static Color32 Chocolate { get { return new Color32(210, 105, 30, 255); } }
        public static Color32 Coral { get { return new Color32(255, 127, 80, 255); } }
        public static Color32 CornflowerBlue { get { return new Color32(100, 149, 237, 255); } }
        public static Color32 Cornsilk { get { return new Color32(255, 248, 220, 255); } }
        public static Color32 Crimson { get { return new Color32(220, 20, 60, 255); } }
        public static Color32 Cyan { get { return new Color32(0, 255, 255, 255); } }
        public static Color32 DarkBlue { get { return new Color32(0, 0, 139, 255); } }
        public static Color32 DarkCyan { get { return new Color32(0, 139, 139, 255); } }
        public static Color32 DarkGoldenrod { get { return new Color32(184, 134, 11, 255); } }
        public static Color32 DarkGray { get { return new Color32(169, 169, 169, 255); } }
        public static Color32 DarkGreen { get { return new Color32(0, 100, 0, 255); } }
        public static Color32 DarkKhaki { get { return new Color32(189, 183, 107, 255); } }
        public static Color32 DarkMagenta { get { return new Color32(139, 0, 139, 255); } }
        public static Color32 DarkOliveGreen { get { return new Color32(85, 107, 47, 255); } }
        public static Color32 DarkOrange { get { return new Color32(255, 140, 0, 255); } }
        public static Color32 DarkOrchid { get { return new Color32(153, 50, 204, 255); } }
        public static Color32 DarkRed { get { return new Color32(139, 0, 0, 255); } }
        public static Color32 DarkSalmon { get { return new Color32(233, 150, 122, 255); } }
        public static Color32 DarkSeaGreen { get { return new Color32(143, 188, 139, 255); } }
        public static Color32 DarkSlateBlue { get { return new Color32(72, 61, 139, 255); } }
        public static Color32 DarkSlateGray { get { return new Color32(47, 79, 79, 255); } }
        public static Color32 DarkTurquoise { get { return new Color32(0, 206, 209, 255); } }
        public static Color32 DarkViolet { get { return new Color32(148, 0, 211, 255); } }
        public static Color32 DeepPink { get { return new Color32(255, 20, 147, 255); } }
        public static Color32 DeepSkyBlue { get { return new Color32(0, 191, 255, 255); } }
        public static Color32 DimGray { get { return new Color32(105, 105, 105, 255); } }
        public static Color32 DodgerBlue { get { return new Color32(30, 144, 255, 255); } }
        public static Color32 Firebrick { get { return new Color32(178, 34, 34, 255); } }
        public static Color32 FloralWhite { get { return new Color32(255, 250, 240, 255); } }
        public static Color32 ForestGreen { get { return new Color32(34, 139, 34, 255); } }
        public static Color32 Fuchsia { get { return new Color32(255, 0, 255, 255); } }
        public static Color32 Gainsboro { get { return new Color32(220, 220, 220, 255); } }
        public static Color32 GhostWhite { get { return new Color32(248, 248, 255, 255); } }
        public static Color32 Gold { get { return new Color32(255, 215, 0, 255); } }
        public static Color32 Goldenrod { get { return new Color32(218, 165, 32, 255); } }
        public static Color32 Gray { get { return new Color32(128, 128, 128, 255); } }
        public static Color32 Green { get { return new Color32(0, 128, 0, 255); } }
        public static Color32 GreenYellow { get { return new Color32(173, 255, 47, 255); } }
        public static Color32 Honeydew { get { return new Color32(240, 255, 240, 255); } }
        public static Color32 HotPink { get { return new Color32(255, 105, 180, 255); } }
        public static Color32 IndianRed { get { return new Color32(205, 92, 92, 255); } }
        public static Color32 Indigo { get { return new Color32(75, 0, 130, 255); } }
        public static Color32 Ivory { get { return new Color32(255, 255, 240, 255); } }
        public static Color32 Khaki { get { return new Color32(240, 230, 140, 255); } }
        public static Color32 Lavender { get { return new Color32(230, 230, 250, 255); } }
        public static Color32 LavenderBlush { get { return new Color32(255, 240, 245, 255); } }
        public static Color32 LawnGreen { get { return new Color32(124, 252, 0, 255); } }
        public static Color32 LemonChiffon { get { return new Color32(255, 250, 205, 255); } }
        public static Color32 LightBlue { get { return new Color32(173, 216, 230, 255); } }
        public static Color32 LightCoral { get { return new Color32(240, 128, 128, 255); } }
        public static Color32 LightCyan { get { return new Color32(224, 255, 255, 255); } }
        public static Color32 LightGoldenrodYellow { get { return new Color32(250, 250, 210, 255); } }
        public static Color32 LightGray { get { return new Color32(211, 211, 211, 255); } }
        public static Color32 LightGreen { get { return new Color32(144, 238, 144, 255); } }
        public static Color32 LightPink { get { return new Color32(255, 182, 193, 255); } }
        public static Color32 LightSalmon { get { return new Color32(255, 160, 122, 255); } }
        public static Color32 LightSeaGreen { get { return new Color32(32, 178, 170, 255); } }
        public static Color32 LightSkyBlue { get { return new Color32(135, 206, 250, 255); } }
        public static Color32 LightSlateGray { get { return new Color32(119, 136, 153, 255); } }
        public static Color32 LightSteelBlue { get { return new Color32(176, 196, 222, 255); } }
        public static Color32 LightYellow { get { return new Color32(255, 255, 224, 255); } }
        public static Color32 Lime { get { return new Color32(0, 255, 0, 255); } }
        public static Color32 LimeGreen { get { return new Color32(50, 205, 50, 255); } }
        public static Color32 Linen { get { return new Color32(250, 240, 230, 255); } }
        public static Color32 Magenta { get { return new Color32(255, 0, 255, 255); } }
        public static Color32 Maroon { get { return new Color32(128, 0, 0, 255); } }
        public static Color32 MediumAquamarine { get { return new Color32(102, 205, 170, 255); } }
        public static Color32 MediumBlue { get { return new Color32(0, 0, 205, 255); } }
        public static Color32 MediumOrchid { get { return new Color32(186, 85, 211, 255); } }
        public static Color32 MediumPurple { get { return new Color32(147, 112, 219, 255); } }
        public static Color32 MediumSeaGreen { get { return new Color32(60, 179, 113, 255); } }
        public static Color32 MediumSlateBlue { get { return new Color32(123, 104, 238, 255); } }
        public static Color32 MediumSpringGreen { get { return new Color32(0, 250, 154, 255); } }
        public static Color32 MediumTurquoise { get { return new Color32(72, 209, 204, 255); } }
        public static Color32 MediumVioletRed { get { return new Color32(199, 21, 133, 255); } }
        public static Color32 MidnightBlue { get { return new Color32(25, 25, 112, 255); } }
        public static Color32 MintCream { get { return new Color32(245, 255, 250, 255); } }
        public static Color32 MistyRose { get { return new Color32(255, 228, 225, 255); } }
        public static Color32 Moccasin { get { return new Color32(255, 228, 181, 255); } }
        public static Color32 NavajoWhite { get { return new Color32(255, 222, 173, 255); } }
        public static Color32 Navy { get { return new Color32(0, 0, 128, 255); } }
        public static Color32 OldLace { get { return new Color32(253, 245, 230, 255); } }
        public static Color32 Olive { get { return new Color32(128, 128, 0, 255); } }
        public static Color32 OliveDrab { get { return new Color32(107, 142, 35, 255); } }
        public static Color32 Orange { get { return new Color32(255, 165, 0, 255); } }
        public static Color32 OrangeRed { get { return new Color32(255, 69, 0, 255); } }
        public static Color32 Orchid { get { return new Color32(218, 112, 214, 255); } }
        public static Color32 PaleGoldenrod { get { return new Color32(238, 232, 170, 255); } }
        public static Color32 PaleGreen { get { return new Color32(152, 251, 152, 255); } }
        public static Color32 PaleTurquoise { get { return new Color32(175, 238, 238, 255); } }
        public static Color32 PaleVioletRed { get { return new Color32(219, 112, 147, 255); } }
        public static Color32 PapayaWhip { get { return new Color32(255, 239, 213, 255); } }
        public static Color32 PeachPuff { get { return new Color32(255, 218, 185, 255); } }
        public static Color32 Peru { get { return new Color32(205, 133, 63, 255); } }
        public static Color32 Pink { get { return new Color32(255, 192, 203, 255); } }
        public static Color32 Plum { get { return new Color32(221, 160, 221, 255); } }
        public static Color32 PowderBlue { get { return new Color32(176, 224, 230, 255); } }
        public static Color32 Purple { get { return new Color32(128, 0, 128, 255); } }
        public static Color32 Red { get { return new Color32(255, 0, 0, 255); } }
        public static Color32 RosyBrown { get { return new Color32(188, 143, 143, 255); } }
        public static Color32 RoyalBlue { get { return new Color32(65, 105, 225, 255); } }
        public static Color32 SaddleBrown { get { return new Color32(139, 69, 19, 255); } }
        public static Color32 Salmon { get { return new Color32(250, 128, 114, 255); } }
        public static Color32 SandyBrown { get { return new Color32(244, 164, 96, 255); } }
        public static Color32 SeaGreen { get { return new Color32(46, 139, 87, 255); } }
        public static Color32 SeaShell { get { return new Color32(255, 245, 238, 255); } }
        public static Color32 Sienna { get { return new Color32(160, 82, 45, 255); } }
        public static Color32 Silver { get { return new Color32(192, 192, 192, 255); } }
        public static Color32 SkyBlue { get { return new Color32(135, 206, 235, 255); } }
        public static Color32 SlateBlue { get { return new Color32(106, 90, 205, 255); } }
        public static Color32 SlateGray { get { return new Color32(112, 128, 144, 255); } }
        public static Color32 Snow { get { return new Color32(255, 250, 250, 255); } }
        public static Color32 SpringGreen { get { return new Color32(0, 255, 127, 255); } }
        public static Color32 SteelBlue { get { return new Color32(70, 130, 180, 255); } }
        public static Color32 Tan { get { return new Color32(210, 180, 140, 255); } }
        public static Color32 Teal { get { return new Color32(0, 128, 128, 255); } }
        public static Color32 Thistle { get { return new Color32(216, 191, 216, 255); } }
        public static Color32 Tomato { get { return new Color32(255, 99, 71, 255); } }
        public static Color32 Turquoise { get { return new Color32(64, 224, 208, 255); } }
        public static Color32 Violet { get { return new Color32(238, 130, 238, 255); } }
        public static Color32 Wheat { get { return new Color32(245, 222, 179, 255); } }
        public static Color32 White { get { return new Color32(255, 255, 255, 255); } }
        public static Color32 WhiteSmoke { get { return new Color32(245, 245, 245, 255); } }
        public static Color32 Yellow { get { return new Color32(255, 255, 0, 255); } }
        public static Color32 YellowGreen { get { return new Color32(154, 205, 50, 255); } }
    }
}
