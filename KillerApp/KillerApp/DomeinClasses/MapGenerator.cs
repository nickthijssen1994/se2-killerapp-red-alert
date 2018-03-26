using System;
using System.Drawing;

namespace KillerApp.DomeinClasses
{
    public class MapGenerator
    {
        public Map GenerateMap(string Name, int Size, int GroundType, int MapType, bool HasLakes, bool HasRivers, int Seed)
        {
            int[,] Tiles = new int[Size, Size];
            Tiles = PerlinNoiseGenerator.GenerateMap(Size, Seed);
            BitmapGenerator bitmapGenerator = new BitmapGenerator();
            Bitmap Image = bitmapGenerator.GenerateBitmap(Tiles);
            Map map = new Map(Name, Size, Tiles, DateTime.Now, GroundType, MapType, HasLakes, HasRivers, Image);
            return map;
        }
    }
}
