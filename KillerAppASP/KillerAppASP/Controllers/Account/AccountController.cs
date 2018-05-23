using KillerAppASP.Models;
using KillerAppASP.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KillerAppASP.Controllers
{
    public class AccountController : Controller
    {
        private UserRepository userRepository;

        public AccountController()
        {
            IUserContext context = new UserMSSQLContext();
            userRepository = new UserRepository(context);
        }

        [HttpGet]
        [Route("")]
        [Route("Account")]
        [Route("Account/Login")]
        [Route("Account/Register")]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "MainMenu");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            bool Success = false;
            string Message = "";
            string Url = "";

            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Username = model.Username,
                    Password = model.Password
                };
                switch (userRepository.LoginUser(user))
                {
                    case 0:
                        var claims = new List<Claim>
                        {
                        new Claim(ClaimTypes.Name, user.Username)
                        };

                        var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            IssuedUtc = DateTimeOffset.UtcNow,
                            IsPersistent = model.RememberMe
                        };
                        var principal = new ClaimsPrincipal(userIdentity);
                        Success = true;
                        Message = "Login Successfull";
                        Url = "/MainMenu";
                        await HttpContext.SignInAsync(principal, authProperties);
                        break;
                    case 1:
                        Message = "Username does not exist";
                        break;
                    case 2:
                        Message = "Password incorrect";
                        break;
                }
            }
            else
            {
                Message = ModelState.ErrorsToHTML();
            }

            return Json(new { success = Success, message = Message, url = Url });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            bool Success = false;
            string Message = "";
            string Url = "";
            bool Login = model.AutoLogin;

            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Email = model.Email,
                    Username = model.Username,
                    Password = model.Password,
                    IsOnline = model.AutoLogin
                };

                switch (userRepository.RegisterUser(user))
                {
                    case 0:
                        var claims = new List<Claim>
                        {
                        new Claim(ClaimTypes.Name, user.Username)
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            IsPersistent = model.RememberMe
                        };
                        Success = true;
                        if (model.AutoLogin == true)
                        {
                            Url = "/MainMenu";
                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                        }
                        else
                        {
                            Url = "/Account";
                            Message = "Registration Successfull";
                        }
                        break;
                    case 1:
                        Message = "Email address already in use";
                        break;
                    case 2:
                        Message = "Username already in use";
                        break;
                }
            }
            else
            {
                Message = ModelState.ErrorsToHTML();
            }

            return Json(new { success = Success, message = Message, url = Url, login = Login });
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            bool Success = false;
            string Message = "";

            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Username = User.Identity.Name,
                    Password = model.OldPassword
                };

                switch (userRepository.ChangePassword(user, model.NewPassword))
                {
                    case 0:
                        Success = true;
                        Message = "Password Changed";
                        break;
                    case 1:
                        Message = "Old Password Incorrect";
                        break;
                }
            }
            else
            {
                Message = ModelState.ErrorsToHTML();
            }
            return Json(new { success = Success, message = Message });
        }

        [HttpGet]
        [Authorize]
        public IActionResult Settings()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            User user = new User
            {
                Username = User.Identity.Name
            };
            userRepository.LogoutUser(user);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Account");
        }
    }
}