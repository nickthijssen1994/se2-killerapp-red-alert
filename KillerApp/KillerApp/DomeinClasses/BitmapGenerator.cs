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
                    switch (Tiles[x, y])
                    {
                        case 1:
                            color = Color.Green;
                            break;
                        case 2:
                            color = Color.White;
                            break;
                        case 3:
                            color = Color.Brown;
                            break;
                        default:
                            color = Color.Blue;
                            break;
                    }
                    bitmap.SetPixel(x, y, color);
                }
            }
            return bitmap;
        }
    }
}
