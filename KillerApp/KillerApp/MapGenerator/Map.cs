namespace MapGenerator
{
    public class Map
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public int Seed { get; set; }
        public int GroundType { get; set; }
        public int MapType { get; set; }
        public bool HasLakes { get; set; }
        public bool HasRivers { get; set; }
        public byte[] PreviewImage { get; set; }
        public byte[] TileImage { get; set; }

        public Map() { }

        public Map(string Name, int Size, int Seed, int GroundType, int MapType, bool HasLakes, bool HasRivers, byte[] PreviewImage)
        {
            this.Name = Name;
            this.Size = Size;
            this.Seed = Seed;
            this.GroundType = GroundType;
            this.MapType = MapType;
            this.HasLakes = HasLakes;
            this.HasRivers = HasRivers;
            this.PreviewImage = PreviewImage;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}