using KillerAppASP.Models;
using System;

namespace KillerAppASP.Helperclasses
{
    public class MapGenerator
    {
        public Map GenerateMap(string Name, int Size, int Seed, int GroundType, int MapType, bool HasLakes, bool HasRivers, string CreatedBy)
        {
            float[,] Array = new float[Size, Size];
            Array = PerlinNoiseGenerator.GenerateMap(Size, Seed);

            if (MapType == 1)
            {
                float[,] islandMask = IslandMaskGenerator.GenerateIslandMask(Size);
                for (int y = 0; y < Size; y++)
                {
                    for (int x = 0; x < Size; x++)
                    {
                        Array[x, y] *= Math.Max(0.0f, 1.0f - islandMask[x, y]);
                        if (Array[x, y] < 0.1f)
                        {
                            Array[x, y] = 0.0f;
                        }
                    }
                }
            }

            byte[] PreviewImage = PreviewImageGenerator.GeneratePreviewImage(Array, GroundType);
            Map map = new Map(Name, Size, Seed, GroundType, MapType, HasLakes, HasRivers, DateTime.Now, CreatedBy, PreviewImage);
            return map;
        }
    }
}
