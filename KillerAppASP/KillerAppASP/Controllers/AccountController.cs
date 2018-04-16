using Microsoft.AspNetCore.Mvc;
using KillerAppASP.Models;

namespace KillerAppASP.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string username, string password)
        {
            return View();
        }

        public IActionResult Register(string email, string username, string password, string confirmpassword)
        {
            return View();
        }
    }
}