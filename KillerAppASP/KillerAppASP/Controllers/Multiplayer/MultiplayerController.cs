﻿using KillerAppASP.Datalayer;
using KillerAppASP.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KillerAppASP.Controllers
{
    [Authorize]
    public class MultiplayerController : Controller
    {
        private UserRepository userRepository;

        public MultiplayerController()
        {
            userRepository = new UserRepository(new UserSQLContext());
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Lobby()
        {
            UserListViewModel model = new UserListViewModel
            {
                Users = userRepository.GetUsers()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult SearchOnlineUsers(string SearchTerm)
        {
            UserListViewModel model = new UserListViewModel();
            if (SearchTerm == null || SearchTerm == "")
            {
                model.Users = userRepository.GetUsers();
            }
            else
            {
                model.Users = userRepository.SearchUsers(SearchTerm);
            }
            return PartialView("OnlineUserList", model);
        }

        [HttpGet]
        public IActionResult SearchAllUsers(string SearchTerm)
        {
            UserListViewModel model = new UserListViewModel();
            if (SearchTerm == null || SearchTerm == "")
            {
                model.Users = userRepository.GetUsers();
            }
            else
            {
                model.Users = userRepository.SearchUsers(SearchTerm);
            }
            return PartialView("AllUserList", model);
        }
    }
}