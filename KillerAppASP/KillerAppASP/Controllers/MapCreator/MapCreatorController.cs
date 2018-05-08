using KillerAppASP.Data;
using KillerAppASP.Models;
using KillerAppASP.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace KillerAppASP.Controllers
{
    [Authorize]
    public class MapCreatorController : Controller
    {
        private MapCreatorRepository mapCreatorRepository;

        public MapCreatorController()
        {
            mapCreatorRepository = new MapCreatorRepository(new MapSQLContext());
        }

        [HttpGet]
        [Route("MapCreator")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GenerateMap(GenerateMapViewModel model)
        {
            bool Success = false;
            string Message = "";

            if (ModelState.IsValid)
            {
                Success = true;
                Message = "Map Generated";
                mapCreatorRepository.GenerateMap(model.Name, model.Size, Convert.ToInt32(model.GroundType), Convert.ToInt32(model.MapType), model.HasLakes, model.HasRivers, model.Seed, User.Identity.Name);
                HttpContext.Session.SetString("Map", JsonConvert.SerializeObject(mapCreatorRepository.Map));
            }
            else
            {
                Message = ModelState.ErrorsToHTML();
            }

            return Json(new { success = Success, message = Message });
        }

        [HttpGet]
        public IActionResult SaveMap()
        {
            bool Success = false;
            string Message = "";

            var map = HttpContext.Session.GetString("Map");
            mapCreatorRepository.Map = JsonConvert.DeserializeObject<Map>(map);

            switch (mapCreatorRepository.SaveMap(User.Identity.Name))
            {
                case 0:
                    Success = true;
                    Message = "Map Saved";
                    break;
                case 1:
                    Message = "A map with this name already exists.";
                    break;
            }

            return Json(new { success = Success, message = Message });
        }

        [HttpDelete]
        public IActionResult DeleteMap(string Mapname)
        {
            bool Success = false;
            string Message = "";

            switch (mapCreatorRepository.DeleteMap(Mapname, User.Identity.Name))
            {
                case 0:
                    Success = true;
                    Message = Mapname + " Deleted";
                    break;
                case 1:
                    Message = "Map doesn't exist.";
                    break;
            }

            return Json(new { success = Success, message = Message });
        }

        [HttpGet]
        public IActionResult GetUserMaps()
        {
            MapListViewModel model = new MapListViewModel();
            mapCreatorRepository.GetUserMaps(User.Identity.Name);
            model.Maps = mapCreatorRepository.Maps;
            return PartialView("MapList", model);
        }

        [HttpGet]
        public IActionResult GetUserMapsWithDelete()
        {
            MapListViewModel model = new MapListViewModel();
            mapCreatorRepository.GetUserMaps(User.Identity.Name);
            model.Maps = mapCreatorRepository.Maps;
            return PartialView("MapListWithDelete", model);
        }

        [HttpGet]
        public IActionResult GetAllMaps()
        {
            MapListViewModel model = new MapListViewModel();
            mapCreatorRepository.GetAllMaps();
            model.Maps = mapCreatorRepository.Maps;
            return View("Index", model);
        }

        [HttpGet]
        public FileStreamResult GetMapPreview(string Mapname)
        {
            if (Mapname != null)
            {
                mapCreatorRepository.GetMap(Mapname, User.Identity.Name);
            }
            var stream = new System.IO.MemoryStream(mapCreatorRepository.Map.Image);
            return new FileStreamResult(stream, "image/png");
        }
    }
}