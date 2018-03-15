using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace KillerApp
{
    class Map
    {
        public enum GroundType { Grass = 1, Snow = 2, Desert = 3};
        public enum MapType { Continent = 1, Island = 2};

        private string name;
        private int size;
        private int[,] tiles;
        private DateTime creationdate;
        private GroundType groundtype;
        private MapType maptype;

        public int[,] Tiles { get { return tiles; } }

        public Map(string Name, int Size, GroundType groundType, MapType mapType, bool HasRivers, bool HasLakes)
        {
            int groundtype = (int)groundType;
            name = Name;
            size = Size;
            tiles = new int[Size, Size];
            creationdate = DateTime.Now;
            this.groundtype = groundType;
            maptype = mapType;
            if (mapType == MapType.Continent)
            {
                for (int y = 0; y < size; y++)
                {
                    for (int x = 0; x < size; x++)
                    {
                        tiles[x, y] = groundtype;
                    }
                }
            }
            else
            {
                for (int y = 0; y < size; y++)
                {
                    for (int x = 0; x < size; x++)
                    {
                        if(x < 10 || x > (size-10) || y < 10 || y > (size - 10))
                        {
                            tiles[x, y] = 0;
                        }
                        else
                        {
                            tiles[x, y] = groundtype;
                        }
                    }
                }
            }
        }
    }
}
