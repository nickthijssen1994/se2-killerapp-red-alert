﻿using System;

namespace KillerAppASP.Models
{
    public class MapGenerator
    {
        public Map GenerateMap(string Name, int Size, int Seed, int GroundType, int MapType, bool HasLakes, bool HasRivers, string CreatedBy)
        {
            int[,] Array = new int[Size, Size];
            Array = PerlinNoiseGenerator.GenerateMap(Size, Seed);
            byte[] Image = ImageGenerator.GenerateImage(Array);
            Map map = new Map(Name, Size, Seed, GroundType, MapType, HasLakes, HasRivers, DateTime.Now, CreatedBy, Image);
            return map;
        }
    }
}
