using System;
using System.Drawing;

namespace KillerApp.DomeinClasses
{
    public class MapGenerator
    {
        public Map GenerateMap(string Name, int Size, int GroundType, int MapType, bool HasLakes, bool HasRivers)
        {
            int[,] tiles = new int[Size, Size];
            if (MapType == (int)Map.MapType.Continent)
            {
                for (int y = 0; y < Size; y++)
                {
                    for (int x = 0; x < Size; x++)
                    {
                        tiles[x, y] = GroundType;
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
                            tiles[x, y] = 0;
                        }
                        else
                        {
                            tiles[x, y] = GroundType;
                        }
                    }
                }
            }
            BitmapGenerator bitmapGenerator = new BitmapGenerator();
            Bitmap Image = bitmapGenerator.GenerateBitmap(tiles);
            Map map = new Map(Name, Size, tiles.ToString(), DateTime.Now, GroundType, MapType, HasLakes, HasRivers, Image);
            return map;
        }
    }
}
