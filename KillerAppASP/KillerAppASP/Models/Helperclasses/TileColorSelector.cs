using System.Drawing;

namespace KillerAppASP.Models
{
    public static class TileColorSelector
    {
        public static Color SelectTileColor(int HeightValue, int GroundType)
        {
            Color color = new Color();
            if (HeightValue == 256)
            {
                color = Color.Black;
            }
            else
            {
                switch (GroundType)
                {
                    case 1: //Snow
                        if (HeightValue <= 55)
                        {
                            color = Color.DodgerBlue;
                        }
                        else if (HeightValue <= 60)
                        {
                            color = Color.SkyBlue;
                        }
                        else if (HeightValue <= 70)
                        {
                            color = Color.LightSlateGray;
                        }
                        else if (HeightValue <= 150)
                        {
                            color = Color.Snow;
                        }
                        else if (HeightValue <= 180)
                        {
                            color = Color.LightGray;
                        }
                        else if (HeightValue <= 195)
                        {
                            color = Color.DarkGray;
                        }
                        else
                        {
                            color = Color.DimGray;
                        }
                        break;
                    case 2: //Desert
                        if (HeightValue <= 55)
                        {
                            color = Color.SkyBlue;
                        }
                        else if (HeightValue <= 60)
                        {
                            color = Color.Green;
                        }
                        else if (HeightValue <= 70)
                        {
                            color = Color.OliveDrab;
                        }
                        else if (HeightValue <= 150)
                        {
                            color = Color.Moccasin;
                        }
                        else if (HeightValue <= 180)
                        {
                            color = Color.BurlyWood;
                        }
                        else if (HeightValue <= 195)
                        {
                            color = Color.Peru;
                        }
                        else
                        {
                            color = Color.SaddleBrown;
                        }
                        break;
                    default: //Grass
                        if (HeightValue <= 55)
                        {
                            color = Color.DodgerBlue;
                        }
                        else if (HeightValue <= 60)
                        {
                            color = Color.SkyBlue;
                        }
                        else if (HeightValue <= 70)
                        {
                            color = Color.BurlyWood;
                        }
                        else if (HeightValue <= 150)
                        {
                            color = Color.Green;
                        }
                        else if (HeightValue <= 180)
                        {
                            color = Color.DarkGreen;
                        }
                        else if (HeightValue <= 195)
                        {
                            color = Color.DarkGray;
                        }
                        else
                        {
                            color = Color.White;
                        }
                        break;
                }
            }
            return color;
        }
    }
}
