namespace MapGenerator
{
    public static class MapGenerator
    {
        public static Map GenerateMap(string Name, int Size, int Seed, int GroundType, int MapType, bool HasLakes, bool HasRivers)
        {
            int[,] Array = new int[Size, Size];
            Array = PerlinNoiseGenerator.GenerateMap(Size, Seed);
            byte[] PreviewImage = PreviewImageGenerator.GeneratePreviewImage(Array);
            Map map = new Map(Name, Size, Seed, GroundType, MapType, HasLakes, HasRivers, PreviewImage);
            return map;
        }
    }
}
