using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerApp.DomeinClasses
{
    public class BitmapGenerator
    {
        public Bitmap GenerateBitmap(int[,] Tiles)
        {
            int width = Tiles.GetLength(1);
            int height = Tiles.GetLength(0);
            Bitmap bitmap = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color color = new Color();
                    int i = Tiles[x, y];
                    //color = Color.FromArgb(i, i, i);
                    if (i <= 55)
                    {
                        color = Color.Blue;
                    }
                    else if (i > 55 && i <= 60)
                    {
                        color = Color.SkyBlue;
                    }
                    else if (i > 60 && i <= 70)
                    {
                        color = Color.SandyBrown;
                    }
                    else if (i > 70 && i <= 150)
                    {
                        color = Color.Green;
                    }
                    else if (i > 150 && i <= 180)
                    {
                        color = Color.DarkGreen;
                    }
                    else if (i > 180 && i <= 195)
                    {
                        color = Color.DarkGray;
                    }
                    else
                    {
                        color = Color.White;
                    }
                    bitmap.SetPixel(x, y, color);
                }
            }
            return bitmap;
        }
    }
}
