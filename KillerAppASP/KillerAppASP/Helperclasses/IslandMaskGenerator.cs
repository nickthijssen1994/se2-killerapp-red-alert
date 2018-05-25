using System;

namespace KillerAppASP.Helperclasses
{
    public static class IslandMaskGenerator
    {
        public static float[,] GenerateIslandMask(int Size)
        {
            float[,] IslandMask = new float[Size, Size];
            float MaxValue = 0;

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

                    if (distance > MaxValue)
                    {
                        MaxValue = distance;
                    }
                }
            }
            return IslandMask;
        }
    }
}
