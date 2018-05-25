using System.Drawing;

namespace KillerAppASP.Helperclasses
{
    public static class TileColorSelector
    {
        private static readonly Color[] GrassColors = new Color[]
        {
            Color.DodgerBlue,
            Color.SkyBlue,
            Color.BurlyWood,
            Color.Green,
            Color.DarkGreen,
            Color.DarkGray,
            Color.White
        };

        private static readonly Color[] SnowColors = new Color[]
        {
            Color.DodgerBlue,
            Color.SkyBlue,
            Color.LightSlateGray,
            Color.Snow,
            Color.LightGray,
            Color.DarkGray,
            Color.DimGray
        };

        private static readonly Color[] DesertColors = new Color[]
        {
            Color.SkyBlue,
            Color.Green,
            Color.OliveDrab,
            Color.Moccasin,
            Color.BurlyWood,
            Color.Peru,
            Color.SaddleBrown
        };

        public static Color SelectTileColor(int HeightValue, int GroundType)
        {
            Color[] ColorList;
            switch (GroundType)
            {
                case 1:
                    ColorList = SnowColors;
                    break;
                case 2:
                    ColorList = DesertColors;
                    break;
                default:
                    ColorList = GrassColors;
                    break;
            }

            if (HeightValue < 0)
            {
                HeightValue = 0;
            }
            if (HeightValue > 255)
            {
                HeightValue = 255;
            }

            //Color color = Color.FromArgb(HeightValue, HeightValue, HeightValue);
            Color color;

            if (HeightValue <= 18)
            {
                color = ColorList[0];
            }
            else if (HeightValue <= 36)
            {
                color = ColorList[1];
            }
            else if (HeightValue <= 60)
            {
                color = ColorList[2];
            }
            else if (HeightValue <= 144)
            {
                color = ColorList[3];
            }
            else if (HeightValue <= 180)
            {
                color = ColorList[4];
            }
            else if (HeightValue <= 216)
            {
                color = ColorList[5];
            }
            else if (HeightValue <= 255)
            {
                color = ColorList[6];
            }
            else
            {
                color = Color.Black;
            }

            return color;
        }
    }
}