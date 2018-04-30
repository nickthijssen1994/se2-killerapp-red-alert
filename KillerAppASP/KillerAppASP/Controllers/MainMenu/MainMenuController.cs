using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KillerAppASP.Controllers
{
    public class MainMenuController : Controller
    {
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Account()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Settings()
        {
            return View();
        }     
    }
}