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
                    if (i <= 20)
                    {
                        color = Color.Blue;
                    }
                    else if (i > 20 && i <= 40)
                    {
                        color = Color.SandyBrown;
                    }
                    else if (i > 40 && i <= 140)
                    {
                        color = Color.Green;
                    }
                    else if (i > 140 && i <= 200)
                    {
                        color = Color.DarkGreen;
                    }
                    else if (i > 200 && i <= 230)
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
