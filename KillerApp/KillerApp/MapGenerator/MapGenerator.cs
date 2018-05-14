using System;

namespace MapGenerator
{
    public static class MapGenerator
    {
        public static Map GenerateMap(string Name, int Size, int Seed, int GroundType, int MapType, bool HasLakes, bool HasRivers)
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

            //if (HasRivers == true)
            //{
            //    float CurrentValue = 0;
            //    int CurrentX = 0;
            //    int CurrentY = 0;

            //    float NextValue = 0;
            //    int NextX = 0;
            //    int NextY = 0;

            //    for (int y = 0; y < Size; y++)
            //    {
            //        for (int x = 0; x < Size; x++)
            //        {
            //            if (Array[x, y] >= CurrentValue)
            //            {
            //                CurrentValue = Array[x, y];
            //                CurrentX = x;
            //                CurrentY = y;
            //                NextValue = Array[x, y];
            //                NextX = x;
            //                NextY = y;
            //            }
            //        }
            //    }

            //    while (CurrentValue > 0.05f)
            //    {
            //        float LowestValue;
            //        int LowestX;
            //        int LowestY;
            //        float ValueAbove = Array[CurrentX, CurrentY--];
            //        float ValueUnder = Array[CurrentX, CurrentY++];
            //        float ValueLeft = Array[CurrentX--, CurrentY];
            //        float ValueRigth = Array[CurrentX++, CurrentY];
            //        LowestValue = ValueAbove;
            //        LowestX = CurrentX;
            //        LowestY = CurrentY--;
            //        if (ValueUnder < ValueAbove)
            //        {
            //            LowestValue = ValueUnder;
            //            LowestX = CurrentX;
            //            LowestY = CurrentY--;
            //        }
            //        if (ValueLeft < ValueUnder)
            //        {
            //            LowestValue = ValueLeft;
            //            LowestX = CurrentX--;
            //            LowestY = CurrentY;
            //        }
            //        if (ValueRigth < ValueLeft)
            //        {
            //            LowestValue = ValueRigth;
            //            LowestX = CurrentX++;
            //            LowestY = CurrentY;
            //        }
            //        Array[LowestX, LowestY] = 0.0f;
            //    }
            //}

            byte[] PreviewImage = PreviewImageGenerator.GeneratePreviewImage(Array, GroundType);
            //byte[] TileImage = TileImageGenerator.GenerateTiles(Array, GroundType);
            Map map = new Map(Name, Size, Seed, GroundType, MapType, HasLakes, HasRivers, PreviewImage/*, TileImage*/);
            return map;
        }
    }
}