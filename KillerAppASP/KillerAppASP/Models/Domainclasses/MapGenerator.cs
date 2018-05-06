using System;

namespace KillerAppASP.Models
{
    public class MapGenerator
    {
        public Map GenerateMap(string Name, int Size, int GroundType, int MapType, bool HasLakes, bool HasRivers, int Seed, string CreatedBy)
        {
            int[,] Array = new int[Size, Size];
            Array = PerlinNoiseGenerator.GenerateMap(Size, Seed);
            Map map = new Map(Name, Size, Array, GroundType, MapType, HasLakes, HasRivers, DateTime.Now, CreatedBy);
            return map;
        }
    }
}
