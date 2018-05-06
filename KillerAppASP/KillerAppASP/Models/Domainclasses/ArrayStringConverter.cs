using System;
using System.Text;

namespace KillerAppASP.Models
{
    public class ArrayStringConverter
    {
        int[,] temporaryArray;
        string temporaryString;

        public string ConvertArrayToString(int Size, int[,] Array)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    stringBuilder.Append(Array[x, y] + " ");
                }
            }
            temporaryString = stringBuilder.ToString();
            return temporaryString;
        }

        public int[,] ConvertStringToArray(int Size, string Array)
        {
            int i = 0;
            temporaryArray = new int[Size, Size];
            string[] stringArray = Array.Split(' ');
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    temporaryArray[x, y] = Convert.ToInt32(stringArray[i]);
                    i++;
                }
            }
            return temporaryArray;
        }
    }
}
