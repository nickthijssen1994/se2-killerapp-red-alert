using KillerAppASP.Datalayer;
using KillerAppASP.Helperclasses;
using KillerAppASP.Interfaces;
using KillerAppASP.Models;
using KillerAppASP.Repositories;
using KillerAppASP.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KillerAppASP.Controllers.Game
{
    [Authorize]
    public class GameController : Controller
    {
        private MapRepository mapRepository;

        public GameController()
        {
            IMapContext context = new MapMSSQLContext();
            mapRepository = new MapRepository(context);
        }

        [HttpGet]
        public IActionResult Index()
        {
            mapRepository.GetMap(TempData.Peek("SelectedMap").ToString(), User.Identity.Name);
            Map map = mapRepository.Map;
            float[,] FloatArray = new float[map.Size, map.Size];
            FloatArray = PerlinNoiseGenerator.GenerateMap(map.Size, map.Seed);

            if (map.MapType == 1)
            {
                FloatArray = IslandMaskGenerator.ApplyIslandMask(map.Size, FloatArray);
            }

            int[,] IntegerArray = new int[map.Size, map.Size];
            for (int y = 0; y < map.Size; y++)
            {
                for (int x = 0; x < map.Size; x++)
                {
                    IntegerArray[x, y] = (int)(FloatArray[x, y] * 256);
                }
            }

            WorldMapViewModel model = new WorldMapViewModel
            {
                Size = map.Size,
                HeightValues = IntegerArray,
                TileSize = 50
            };
            return View(model);
        }
    }
}