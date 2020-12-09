using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace KillerAppASP.Helperclasses
{
	public static class PreviewImageGenerator
	{
		public static byte[] GeneratePreviewImage(float[,] Array, int GroundType)
		{
			var width = Array.GetLength(1);
			var height = Array.GetLength(0);
			var bitmap = new Bitmap(width, height);

			for (var y = 0; y < height; y++)
			{
				for (var x = 0; x < width; x++)
				{
					var HeightValue = (int) (Array[x, y] * 256);
					var color = TileColorSelector.SelectTileColor(HeightValue, GroundType);
					bitmap.SetPixel(x, y, color);
				}
			}

			Image image = bitmap;
			byte[] imageBytes;
			var memoryStream = new MemoryStream();
			image.Save(memoryStream, ImageFormat.Png);
			imageBytes = memoryStream.ToArray();
			return imageBytes;
		}
	}
}