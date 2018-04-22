using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using System.Text;
using KillerAppASP.Models;
using KillerAppASP.Data;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace KillerAppASP.Controllers
{
    public class AccountController : Controller
    {
        AccountRepository accountRepository = null;

        public AccountController()
        {
            IAccountContext context = new AccountSQLContext();
            accountRepository = new AccountRepository(context);
        }

        [HttpGet]
        public IActionResult Index()
        {
            LoginAndRegisterViewModel loginAndRegisterViewModel = new LoginAndRegisterViewModel();
            loginAndRegisterViewModel.LoginModel = new LoginViewModel();
            loginAndRegisterViewModel.RegisterModel = new RegisterViewModel();
            return View(loginAndRegisterViewModel);
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
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            LoginAndRegisterViewModel loginAndRegisterViewModel = new LoginAndRegisterViewModel();
            loginAndRegisterViewModel.LoginModel = loginViewModel;
            loginAndRegisterViewModel.RegisterModel = new RegisterViewModel();

            if (ModelState.IsValid)
            {
                User user = new User();
                user.Username = loginViewModel.LoginUsername;
                user.Password = EncryptPassword(loginViewModel.LoginPassword);
                bool authorized = accountRepository.LoginUser(user);
                if(authorized == true)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username)
                    };
                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    TempData["UserName"] = user.Username;
                    TempData["LoginSuccessfull"] = "Welcome back Comrad " + user.Username;
                    return RedirectToAction("Index", "MainMenu");
                }
                else
                {
                    TempData["UserLoginFailed"] = "Username or password incorrect";
                    return View("Index", loginAndRegisterViewModel);
                }
            }
            else
            {
                return View("Index", loginAndRegisterViewModel);
            }
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            LoginAndRegisterViewModel loginAndRegisterViewModel = new LoginAndRegisterViewModel();
            loginAndRegisterViewModel.LoginModel = new LoginViewModel();
            loginAndRegisterViewModel.RegisterModel = registerViewModel;

            if (ModelState.IsValid)
            {
                return View("Index", loginAndRegisterViewModel);
            }
            else
            {
                return View("Index", loginAndRegisterViewModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            TempData["UserName"] = null;
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Account");
        }

        private string EncryptPassword(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(Encoding.Unicode.GetBytes(password));
            string encryptedPassword = BitConverter.ToString(bytes).Replace("-", string.Empty);
            return encryptedPassword;
        }
    }
}