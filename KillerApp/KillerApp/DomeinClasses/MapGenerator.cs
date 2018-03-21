using System;
using System.Drawing;

namespace KillerApp.DomeinClasses
{
    public class MapGenerator
    {
        public Map GenerateMap(string Name, int Size, int GroundType, int MapType, bool HasLakes, bool HasRivers)
        {
            int[,] Tiles = new int[Size, Size];
            if (MapType == (int)Map.MapType.Continent)
            {
                for (int y = 0; y < Size; y++)
                {
                    for (int x = 0; x < Size; x++)
                    {
                        Tiles[x, y] = GroundType;
                    }
                }
            }
            else if (MapType == (int)Map.MapType.Island)
            {
                for (int y = 0; y < Size; y++)
                {
                    for (int x = 0; x < Size; x++)
                    {
                        if (x < 10 || x > (Size - 10) || y < 10 || y > (Size - 10))
                        {
                            Tiles[x, y] = 0;
                        }
                        else
                        {
                            Tiles[x, y] = GroundType;
                        }
                    }
                }
            }
            BitmapGenerator bitmapGenerator = new BitmapGenerator();
            Bitmap Image = bitmapGenerator.GenerateBitmap(Tiles);
            Map map = new Map(Name, Size, Tiles, DateTime.Now, GroundType, MapType, HasLakes, HasRivers, Image);
            return map;
        }
    }
}
