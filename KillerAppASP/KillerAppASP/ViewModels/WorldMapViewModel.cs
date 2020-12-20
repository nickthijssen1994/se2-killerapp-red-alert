using System.Drawing;

namespace KillerAppASP.ViewModels
{
	public class WorldMapViewModel
	{
		public string MapName { get; set; }
		public int TileSize { get; set; }
		public int Size { get; set; }
		public int[,] HeightValues { get; set; }
		
		public Color[,] TileColors { get; set; }
	}
}
