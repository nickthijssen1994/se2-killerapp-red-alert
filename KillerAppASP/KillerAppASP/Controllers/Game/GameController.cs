using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KillerAppASP.Controllers.Game
{
    [Authorize]
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}