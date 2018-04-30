using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KillerAppASP.Models;
using KillerAppASP.Data;
using KillerAppASP.ViewModels;
using System;

namespace KillerAppASP.Controllers
{
    public class MapCreatorController : Controller
    {
        MapCreatorRepository mapCreatorRepository = null;

        public MapCreatorController()
        {
            IMapContext mapContext = new MapSQLContext();
            mapCreatorRepository = new MapCreatorRepository(mapContext);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index(MapCreatorViewModel _mapCreatorViewModel)
        {
            MapCreatorViewModel mapCreatorViewModel = _mapCreatorViewModel;
            mapCreatorRepository.GetMaps();
            mapCreatorViewModel.GenerateViewModel = _mapCreatorViewModel.GenerateViewModel;
            foreach (Map map in mapCreatorRepository.Maps)
            {
                mapCreatorViewModel.ListViewModel.AllMaps.Add(map);
            }
            return View(mapCreatorViewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult GenerateMap(MapCreatorViewModel mcvm)
        {
            mcvm.ListViewModel = new MapListViewModel();
            MapGenerateViewModel vm = mcvm.GenerateViewModel;
            if (ModelState.IsValid)
            {
                mapCreatorRepository.GenerateMap(vm.MapName, vm.MapSize, Convert.ToInt32(vm.MapGroundType), Convert.ToInt32(vm.MapType), vm.HasLakes, vm.HasRivers, vm.MapSeed);
            }
            return RedirectToAction("Index", "MapCreator");
        }

        [HttpPost]
        [Authorize]
        public IActionResult SaveMap()
        {
            mapCreatorRepository.SaveMap();
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult DeleteMap(MapListViewModel vm)
        {
            mapCreatorRepository.DeleteMap(vm.SearchTerm);
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult GetMap(MapListViewModel vm)
        {
            mapCreatorRepository.GetMap(vm.SearchTerm);
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult GetAllMaps()
        {
            mapCreatorRepository.GetMaps();
            return View();
        }
    }
}