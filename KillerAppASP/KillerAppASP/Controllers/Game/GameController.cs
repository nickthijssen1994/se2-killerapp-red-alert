using KillerAppASP.Models;
using KillerAppASP.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

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
                float[,] islandMask = IslandMaskGenerator.GenerateIslandMask(map.Size);
                for (int y = 0; y < map.Size; y++)
                {
                    for (int x = 0; x < map.Size; x++)
                    {
                        FloatArray[x, y] *= Math.Max(0.0f, 1.0f - islandMask[x, y]);
                        if (FloatArray[x, y] < 0.1f)
                        {
                            FloatArray[x, y] = 0.0f;
                        }
                    }
                }
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