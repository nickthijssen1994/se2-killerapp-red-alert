using KillerAppASP.Datalayer;
using KillerAppASP.Models;
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
            mapRepository = new MapRepository(new MapSQLContext());
        }

        [HttpGet]
        public IActionResult Index()
        {
            mapRepository.GetMap("DesertMap3", User.Identity.Name);
            Map map = mapRepository.Map;
            int[,] Array = new int[map.Size, map.Size];
            Array = PerlinNoiseGenerator.GenerateMap(map.Size, map.Seed);
            WorldMapViewModel model = new WorldMapViewModel
            {
                Size = map.Size,
                HeightValues = Array,
                TileSize = 50
            };
            return View(model);
        }
    }
}