using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace MapGenerator
{
    public static class TileImageGenerator
    {
        public static byte[] GenerateTiles(int[,] Array, int GroundType)
        {
            int tileSize = 20;
            int inputWidth = Array.GetLength(1);
            int inputHeight = Array.GetLength(0);
            int outputWidth = inputWidth * tileSize;
            int outputHeight = inputHeight * tileSize;
            int[,] tile = new int[tileSize, tileSize];
            Bitmap bitmap = new Bitmap(outputWidth, outputHeight);

            for (int y = 0; y < inputHeight; y++)
            {
                for (int x = 0; x < inputWidth; x++)
                {
                    int heightValue = Array[x, y];
                    tile = GenerateTile(heightValue, tileSize);
                    for (int yPixel = 0; yPixel < tileSize; yPixel++)
                    {
                        for (int xPixel = 0; xPixel < tileSize; xPixel++)
                        {
                            int tilePixel = tile[xPixel, yPixel];
                            Color color = TileColorSelector.SelectTileColor(tilePixel, GroundType);
                            bitmap.SetPixel(xPixel + (tileSize * x), yPixel + (tileSize * y), color);
                        }
                    }
                }
            }

            Image image = bitmap;
            byte[] imageBytes;
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Png);
            imageBytes = memoryStream.ToArray();
            return imageBytes;
        }

        private static int[,] GenerateTile(int value, int size)
        {
            int[,] tile = new int[size, size];
            for (int height = 0; height < size; height++)
            {
                for (int width = 0; width < size; width++)
                {
                    if (width == 0 || width == (size - 1) || height == 0 || height == (size - 1))
                    {
                        tile[width, height] = 256;
                    }
                    else
                    {
                        tile[width, height] = value;
                    }
                }
            }
            return tile;
        }
    }
}