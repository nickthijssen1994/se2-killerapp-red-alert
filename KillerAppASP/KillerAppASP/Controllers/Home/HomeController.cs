using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KillerAppASP.ViewModels;
using Microsoft.AspNetCore.Http;

namespace KillerAppASP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            CookieOptions options = new CookieOptions();
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
