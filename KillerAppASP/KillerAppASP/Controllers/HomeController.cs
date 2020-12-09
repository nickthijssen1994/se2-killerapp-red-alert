using System.Diagnostics;
using KillerAppASP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KillerAppASP.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Error()
		{
			return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
		}
	}
}