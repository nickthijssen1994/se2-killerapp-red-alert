using KillerAppASP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KillerAppASP.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            LoginOrRegisterViewModel loginOrRegisterViewModel = new LoginOrRegisterViewModel();
            loginOrRegisterViewModel.LoginModel = new LoginViewModel();
            loginOrRegisterViewModel.RegisterModel = new RegisterViewModel();
            return View(loginOrRegisterViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                LoginOrRegisterViewModel loginOrRegisterViewModel = new LoginOrRegisterViewModel();
                loginOrRegisterViewModel.LoginModel = loginViewModel;
                return View("Index", loginOrRegisterViewModel);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                LoginOrRegisterViewModel loginOrRegisterViewModel = new LoginOrRegisterViewModel();
                loginOrRegisterViewModel.RegisterModel = registerViewModel;
                return View("Index", loginOrRegisterViewModel);
            }
            else
            {
                return View();
            }
        }
    }
}