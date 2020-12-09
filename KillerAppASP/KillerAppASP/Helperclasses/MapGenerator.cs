using KillerAppASP.Models;
using System;

namespace KillerAppASP.Helperclasses
{
	public class MapGenerator
	{
		public Map GenerateMap(string Name, int Size, int Seed, int GroundType, int MapType, bool HasLakes,
			bool HasRivers, string CreatedBy)
		{
			var Array = new float[Size, Size];
			Array = PerlinNoiseGenerator.GenerateMap(Size, Seed);

			if (MapType == 1) Array = IslandMaskGenerator.ApplyIslandMask(Size, Array);

			var PreviewImage = PreviewImageGenerator.GeneratePreviewImage(Array, GroundType);
			var map = new Map(Name, Size, Seed, GroundType, MapType, HasLakes, HasRivers, DateTime.Now, CreatedBy,
				PreviewImage);
			return map;
		}
	}
}