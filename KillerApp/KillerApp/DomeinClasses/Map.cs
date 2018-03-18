using System;
using System.Drawing;

namespace KillerApp
{
    public class Map
    {
        public enum GroundType { Grass = 1, Snow = 2, Desert = 3}
        public enum MapType { Continent = 0, Island = 1}
        
        private string name;
        private int size;
        private string tiles;
        private DateTime creationdate;
        private int groundtype;
        private int maptype;
        private bool haslakes;
        private bool hasrivers;
        private Bitmap image;
        
        public string Name { get => name; set => name = value;}
        public int Size { get => size; set => size = value; }
        public string Tiles { get => tiles; set => tiles = value; }
        public DateTime Creationdate { get => creationdate; set => creationdate = value; }
        public int Groundtype { get => groundtype; set => groundtype = value; }
        public int Maptype { get => maptype; set => maptype = value; }
        public bool Haslakes { get => haslakes; set => haslakes = value; }
        public bool Hasrivers { get => hasrivers; set => hasrivers = value; }
        public Bitmap Image { get => image; set => image = value; }

        public Map(string Name, int Size, int GroundType, int MapType)
        {
            this.Name = Name;
            this.Size = Size;
            Creationdate = DateTime.Now;
            Groundtype = GroundType;
            Maptype = MapType;
        }

        public Map(string Name, int Size, string Tiles, DateTime CreationDate, int GroundType, int MapType)
        {
            this.Name = Name;
            this.Size = Size;
            this.Tiles = Tiles;
            Creationdate = CreationDate;
            Groundtype = GroundType;
            Maptype = MapType;
        }

        public Map(string Name, int Size, string Tiles, DateTime CreationDate, int GroundType, int MapType, bool HasLakes, bool HasRivers, Bitmap Image)
        {
            this.Name = Name;
            this.Size = Size;
            this.Tiles = Tiles;
            Creationdate = CreationDate;
            Groundtype = GroundType;
            Maptype = MapType;
            Haslakes = HasLakes;
            Hasrivers = HasRivers;
            this.Image = Image;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
