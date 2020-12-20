using System.Drawing;
using KillerAppASP.Datalayer;
using KillerAppASP.Helperclasses;
using KillerAppASP.Interfaces;
using KillerAppASP.Repositories;
using KillerAppASP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KillerAppASP.Controllers.Game
{
	public class GameController : Controller
	{
		private readonly MapRepository mapRepository;

		public GameController()
		{
			IMapContext context = new MapMSSQLContext();
			mapRepository = new MapRepository(context);
		}

		[HttpGet]
		public IActionResult Index()
		{
			mapRepository.GetMap(TempData.Peek("SelectedMap").ToString(), User.Identity.Name);
			var map = mapRepository.Map;
			var FloatArray = new float[map.Size, map.Size];
			FloatArray = PerlinNoiseGenerator.GenerateMap(map.Size, map.Seed);

			if (map.MapType == 1) FloatArray = IslandMaskGenerator.ApplyIslandMask(map.Size, FloatArray);

			var IntegerArray = new int[map.Size, map.Size];
			for (var y = 0; y < map.Size; y++)
			{
				for (var x = 0; x < map.Size; x++)
				{
					IntegerArray[x, y] = (int) (FloatArray[x, y] * 256);
				}
			}
			
			var width = map.Size;
			var height = map.Size;
			var ColorArray = new Color[map.Size, map.Size];

			for (var y = 0; y < height; y++)
			{
				for (var x = 0; x < width; x++)
				{
					var HeightValue = IntegerArray[x, y];
					var color = TileColorSelector.SelectTileColor(HeightValue, map.GroundType);
					ColorArray[x, y] = color;
				}
			}

			var model = new WorldMapViewModel
			{
				MapName = map.Name,
				Size = map.Size,
				HeightValues = IntegerArray,
				TileSize = 50,
				TileColors = ColorArray
			};
			return View(model);
		}
	}
}
