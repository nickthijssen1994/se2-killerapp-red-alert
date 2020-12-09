using KillerAppASP.Datalayer;
using KillerAppASP.Interfaces;
using KillerAppASP.Repositories;
using KillerAppASP.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KillerAppASP.Controllers
{
	[Authorize]
	public class SingleplayerController : Controller
	{
		private MapRepository mapRepository;

		public SingleplayerController()
		{
			IMapContext context = new MapMSSQLContext();
			mapRepository = new MapRepository(context);
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult StartGame(StartGameViewModel model)
		{
			return View("Index", model);
		}
	}
}