namespace MapGenerator
{
    public static class BitmapViewGenerator
    {
        //public static Bitmap GenerateBitmapView(Map map, int x, int y)
        //{
        //    int[,] tiles = map.Tiles;
        //    int[,] temptiles = new int[20, 20];
        //    int tempX = 0;
        //    int tempY = 0;
        //    for (int j = y; j < (y + 20); j++)
        //    {
        //        for (int i = x; i < (x + 20); i++)
        //        {
        //            temptiles[tempX, tempY] = tiles[i, j];
        //            tempX++;
        //        }
        //        tempX = 0;
        //        tempY++;
        //    }
        //    Bitmap view = new Bitmap(20, 20);
        //    for (int j = 0; j < 20; j++)
        //    {
        //        for (int i = 0; i < 20; i++)
        //        {
        //            Color color = new Color();
        //            int c = temptiles[i, j];
        //            if (c <= 55)
        //            {
        //                color = Color.Blue;
        //            }
        //            else if (c > 55 && c <= 60)
        //            {
        //                color = Color.SkyBlue;
        //            }
        //            else if (c > 60 && c <= 70)
        //            {
        //                color = Color.SandyBrown;
        //            }
        //            else if (c > 70 && c <= 150)
        //            {
        //                color = Color.Green;
        //            }
        //            else if (c > 150 && c <= 180)
        //            {
        //                color = Color.DarkGreen;
        //            }
        //            else if (c > 180 && c <= 195)
        //            {
        //                color = Color.DarkGray;
        //            }
        //            else
        //            {
        //                color = Color.White;
        //            }
        //            view.SetPixel(i, j, color);
        //        }
        //    }
        //    return view;
        //}

        //private static float Scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue)
        //{
        //    float OldRange = OldMax - OldMin;
        //    float NewRange = NewMax - NewMin;
        //    float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;
        //    return NewValue;
        //}
    }
}
