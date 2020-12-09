using System;
using System.IO;
using System.Text.Json;
using KillerAppASP.Datalayer;
using KillerAppASP.Helperclasses;
using KillerAppASP.Interfaces;
using KillerAppASP.Models;
using KillerAppASP.Repositories;
using KillerAppASP.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KillerAppASP.Controllers
{
	[Authorize]
	public class MapCreatorController : Controller
	{
		private readonly MapRepository mapRepository;

		public MapCreatorController()
		{
			IMapContext context = new MapMSSQLContext();
			mapRepository = new MapRepository(context);
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
			var Success = false;
			var Message = "";

			if (ModelState.IsValid)
			{
				Success = true;
				Message = "Map Generated";

				mapRepository.GenerateMap
				(
					model.Name,
					model.Size,
					model.Seed,
					Convert.ToInt32(model.GroundType),
					Convert.ToInt32(model.MapType),
					model.HasLakes,
					model.HasRivers,
					User.Identity.Name
				);

				HttpContext.Session.SetString("Map", JsonSerializer.Serialize(mapRepository.Map));
			}
			else
			{
				Message = ModelState.ErrorsToHTML();
			}

			return Json(new {success = Success, message = Message});
		}

		[HttpGet]
		public IActionResult SaveMap()
		{
			var Success = false;
			var Message = "";

			var map = HttpContext.Session.GetString("Map");
			mapRepository.Map = JsonSerializer.Deserialize<Map>(map);

			switch (mapRepository.SaveMap(User.Identity.Name))
			{
				case 0:
					Success = true;
					Message = "Map Saved";
					break;
				case 1:
					Message = "A map with this name already exists.";
					break;
			}

			return Json(new {success = Success, message = Message});
		}

		[HttpDelete]
		public IActionResult DeleteMap(string Mapname)
		{
			var Success = false;
			var Message = "";

			switch (mapRepository.DeleteMap(Mapname, User.Identity.Name))
			{
				case 0:
					Success = true;
					Message = Mapname + " Deleted";
					break;
				case 1:
					Message = "Map doesn't exist.";
					break;
			}

			return Json(new {success = Success, message = Message});
		}

		[HttpGet]
		public IActionResult GetUserMaps()
		{
			var model = new MapListViewModel();
			mapRepository.GetUserMaps(User.Identity.Name);
			model.Maps = mapRepository.Maps;
			return PartialView("_MapList", model);
		}

		[HttpGet]
		public IActionResult GetUserMapsWithDelete()
		{
			var model = new MapListViewModel();
			mapRepository.GetUserMaps(User.Identity.Name);
			model.Maps = mapRepository.Maps;
			return PartialView("MapListWithDelete", model);
		}

		[HttpGet]
		public IActionResult GetAllMaps()
		{
			var model = new MapListViewModel();
			mapRepository.GetAllMaps();
			model.Maps = mapRepository.Maps;
			return PartialView("_MapList", model);
		}

		[HttpGet]
		public FileStreamResult GetMapPreview(string Mapname)
		{
			if (Mapname != null)
			{
				mapRepository.GetMap(Mapname, User.Identity.Name);
				TempData["SelectedMap"] = mapRepository.Map.Name;
			}

			var stream = new MemoryStream(mapRepository.Map.Image);
			return new FileStreamResult(stream, "image/png");
		}
	}
}