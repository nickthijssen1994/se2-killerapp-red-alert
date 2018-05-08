using KillerAppASP.Data;
using KillerAppASP.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KillerAppASP.Controllers
{
    [Authorize]
    public class MultiplayerController : Controller
    {
        private AccountRepository accountRepository;

        public MultiplayerController()
        {
            accountRepository = new AccountRepository(new AccountSQLContext());
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
                OnlineUsers = accountRepository.GetOnlineUsers(),
                AllUsers = accountRepository.GetAllUsers()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult GetOnlineUsers(UserListViewModel model)
        {
            model.OnlineUsers = accountRepository.GetOnlineUsers();
            return PartialView("OnlineUserList", model);
        }

        [HttpGet]
        public IActionResult GetAllUsers(UserListViewModel model)
        {
            model.AllUsers = accountRepository.GetAllUsers();
            return PartialView("AllUserList", model);
        }
    }
}