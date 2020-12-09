using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KillerAppASP.Controllers
{
	[Authorize]
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