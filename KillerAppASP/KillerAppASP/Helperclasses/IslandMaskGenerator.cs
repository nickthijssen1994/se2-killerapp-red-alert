using System;

namespace KillerAppASP.Helperclasses
{
	public static class IslandMaskGenerator
	{
		private static float[,] GenerateIslandMask(int Size)
		{
			var IslandMask = new float[Size, Size];

			for (var y = 0; y < Size; y++)
			{
				for (var x = 0; x < Size; x++)
				{
					var distanceX = Math.Abs(x - Size * 0.5f);
					var distanceY = Math.Abs(y - Size * 0.5f);
					//float distanceFromCenter = Math.Max(distanceX, distanceY);
					var distanceFromCenter = (float) Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
					var IslandSize = Size * 0.5f - Size / 100.0f;
					var distance = distanceFromCenter / IslandSize;
					distance *= distance;

					IslandMask[x, y] = distance;
				}
			}

			return IslandMask;
		}

		public static float[,] ApplyIslandMask(int Size, float[,] Array)
		{
			var TempArray = Array;
			var islandMask = GenerateIslandMask(Size);
			for (var y = 0; y < Size; y++)
			{
				for (var x = 0; x < Size; x++)
				{
					TempArray[x, y] *= Math.Max(0.0f, 1.0f - islandMask[x, y]);
					if (TempArray[x, y] < 0.1f) TempArray[x, y] = 0.0f;
				}
			}

			return TempArray;
		}
	}
}