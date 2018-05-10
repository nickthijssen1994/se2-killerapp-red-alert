using KillerAppASP.Datalayer;
using KillerAppASP.Models;
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

        public IActionResult Index()
        {
            return View();
        }

        public FileStreamResult GetMapTiles()
        {
            mapRepository.GetMap("DesertMap3", User.Identity.Name);
            Map map = mapRepository.Map;
            int[,] Array = new int[map.Size, map.Size];
            Array = PerlinNoiseGenerator.GenerateMap(map.Size, map.Seed);
            var stream = new System.IO.MemoryStream(TileImageGenerator.GenerateTiles(Array, map.GroundType));
            return new FileStreamResult(stream, "image/png");
        }
    }
}