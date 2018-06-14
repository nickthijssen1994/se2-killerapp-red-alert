using System;

namespace KillerAppASP.Helperclasses
{
    public static class IslandMaskGenerator
    {
        private static float[,] GenerateIslandMask(int Size)
        {
            float[,] IslandMask = new float[Size, Size];

            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    float distanceX = Math.Abs(x - Size * 0.5f);
                    float distanceY = Math.Abs(y - Size * 0.5f);
                    //float distanceFromCenter = Math.Max(distanceX, distanceY);
                    float distanceFromCenter = (float)Math.Sqrt((distanceX * distanceX) + (distanceY * distanceY));
                    float IslandSize = Size * 0.5f - (Size / 100.0f);
                    float distance = distanceFromCenter / IslandSize;
                    distance *= distance;

                    IslandMask[x, y] = distance;
                }
            }
            return IslandMask;
        }

        public static float[,] ApplyIslandMask(int Size, float[,] Array)
        {
            float[,] TempArray = Array;
            float[,] islandMask = GenerateIslandMask(Size);
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    TempArray[x, y] *= Math.Max(0.0f, 1.0f - islandMask[x, y]);
                    if (TempArray[x, y] < 0.1f)
                    {
                        TempArray[x, y] = 0.0f;
                    }
                }
            }
            return TempArray;
        }
    }
}
