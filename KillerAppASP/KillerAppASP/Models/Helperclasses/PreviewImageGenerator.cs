using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace KillerAppASP.Models
{
    public static class PreviewImageGenerator
    {
        public static byte[] GeneratePreviewImage(float[,] Array, int GroundType)
        {
            int width = Array.GetLength(1);
            int height = Array.GetLength(0);
            Bitmap bitmap = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int HeightValue = (int)(Array[x, y] * 256);
                    Color color = TileColorSelector.SelectTileColor(HeightValue, GroundType);
                    bitmap.SetPixel(x, y, color);
                }
            }

            Image image = bitmap;
            byte[] imageBytes;
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Png);
            imageBytes = memoryStream.ToArray();
            return imageBytes;
        }
    }
}