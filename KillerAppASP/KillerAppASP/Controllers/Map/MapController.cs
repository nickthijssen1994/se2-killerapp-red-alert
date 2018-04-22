using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using KillerAppASP.Models;
using KillerAppASP.Data;

namespace KillerAppASP.Controllers
{
    public class MapController : Controller
    {
        IMapContext mapContext;
        MapRepository mapRepository;
        private static MapController instance;

        private MapController()
        {
            mapContext = new MapSQLContext();
            mapRepository = new MapRepository(mapContext);
        }

        public void GenerateMap(string Name, int Size, int GroundType, int MapType, bool HasLakes, bool HasRivers, int Seed)
        {
            if (Name != null || Name != "")
            {
                mapRepository.GenerateMap(Name, Size, GroundType, MapType, HasLakes, HasRivers, Seed);
            }
        }

        public void SaveMap()
        {
            mapRepository.SaveMap();
        }

        public Map GetMap()
        {
            return mapRepository.Map;
        }

        public List<Map> GetMaps()
        {
            mapRepository.GetMaps();
            return mapRepository.Maps;
        }

        public void DeleteMap(string name)
        {
            mapRepository.DeleteMap(name);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
