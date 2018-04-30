using System;
using System.Drawing;

namespace KillerAppASP.Models
{
    public class Map
    {
        public string Name { get; set;}
        public int Size { get; set; }
        public int[,] Tiles { get; set; }
        public DateTime Creationdate { get; set; }
        public int Groundtype { get; set; }
        public int Maptype { get; set; }
        public bool Haslakes { get; set; }
        public bool Hasrivers { get; set; }
        public Bitmap Image { get; set; }

        public Map(string Name, int Size, int GroundType, int MapType)
        {
            this.Name = Name;
            this.Size = Size;
            Creationdate = DateTime.Now;
            Groundtype = GroundType;
            Maptype = MapType;
        }

        public Map(string Name, int Size, int[,] Tiles, DateTime CreationDate, int GroundType, int MapType)
        {
            this.Name = Name;
            this.Size = Size;
            this.Tiles = Tiles;
            Creationdate = CreationDate;
            Groundtype = GroundType;
            Maptype = MapType;
        }

        public Map(string Name, int Size, int[,] Tiles, DateTime CreationDate, int GroundType, int MapType, bool HasLakes, bool HasRivers, Bitmap Image)
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
