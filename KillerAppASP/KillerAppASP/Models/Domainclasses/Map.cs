using System;

namespace KillerAppASP.Models
{
    public class Map
    {
        public int MapID { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int[,] Array { get; set; }
        public int GroundType { get; set; }
        public int MapType { get; set; }
        public bool HasLakes { get; set; }
        public bool HasRivers { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public byte[] Image { get; set; }

        public Map() { }

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
            ImageGenerator imageGenerator = new ImageGenerator();
            Image = imageGenerator.GenerateImage(Array);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
