using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerApp.DomeinClasses
{
    public class ArrayStringConverter
    {
        int[,] temporaryArray;
        string temporaryString = "";

        public string ConvertArrayToString(int Size, int[,] Array)
        {
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    temporaryString += Array[x, y] + " ";
                }
            }
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
