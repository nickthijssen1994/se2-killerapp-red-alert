using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace MapGenerator
{
    public static class TilesImageGenerator
    {
        public static byte[] GenerateTilesImage(int[,] Array, int TileSize)
        {
            int width = Array.GetLength(1) * TileSize;
            int height = Array.GetLength(0) * TileSize;
            Bitmap tilesBitmap = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color color = new Color();
                    int i = Array[x, y];
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
                    tilesBitmap.SetPixel(x, y, color);
                }
            }

            Image image = tilesBitmap;
            byte[] imageBytes;
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Png);
            imageBytes = memoryStream.ToArray();
            return imageBytes;
        }
    }
}
