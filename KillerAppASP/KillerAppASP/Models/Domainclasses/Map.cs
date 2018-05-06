using System;
using System.Drawing;

namespace KillerAppASP.Models
{
    public class Map
    {
        public int MapID { get; set; }
        public string Name { get; set;}
        public int Size { get; set; }
        public int[,] Array { get; set; }
        public int GroundType { get; set; }
        public int MapType { get; set; }
        public bool HasLakes { get; set; }
        public bool HasRivers { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }

        public Map(string Name, int Size, int[,] Array, int GroundType, int MapType, bool HasLakes, bool HasRivers, DateTime CreationDate, string CreatedBy)
        {
            this.Name = Name;
            this.Size = Size;
            this.Array = Array;
            this.GroundType = GroundType;
            this.MapType = MapType;
            this.HasLakes = HasLakes;
            this.HasRivers = HasRivers;
            this.CreationDate = CreationDate;
            this.CreatedBy = CreatedBy;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
