﻿using Microsoft.AspNetCore.Mvc;

namespace KillerAppASP.Controllers
{
	public class MainMenuController : Controller
	{
		[HttpGet]
		[Route("/MainMenu")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
