using KillerAppASP.Datalayer;
using KillerAppASP.Interfaces;
using KillerAppASP.Repositories;
using KillerAppASP.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KillerAppASP.Controllers
{
	[Authorize]
	public class MultiplayerController : Controller
	{
		private UserRepository userRepository;
		private ChatRepository chatRepository;

		public MultiplayerController()
		{
			IUserContext userContext = new UserMSSQLContext();
			IChatContext chatContext = new ChatMSSQLContext();
			userRepository = new UserRepository(userContext);
			chatRepository = new ChatRepository(chatContext);
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Lobby()
		{
			var globalChat = new GlobalChatViewModel
			{
				GlobalMessages = chatRepository.GetGlobalMessages()
			};

			var userModel = new UserListViewModel
			{
				Users = userRepository.GetUsers()
			};

			var model = new MultiplayerViewModel
			{
				chatModel = globalChat,
				userModel = userModel
			};

			return View(model);
		}

		[HttpGet]
		public IActionResult SearchOnlineUsers(string SearchTerm)
		{
			var globalChat = new GlobalChatViewModel
			{
				GlobalMessages = chatRepository.GetGlobalMessages()
			};

			var userModel = new UserListViewModel();
			if (SearchTerm == null || SearchTerm == "")
				userModel.Users = userRepository.GetUsers();
			else
				userModel.Users = userRepository.SearchUsers(SearchTerm);

			var model = new MultiplayerViewModel
			{
				chatModel = globalChat,
				userModel = userModel
			};

			return PartialView("OnlineUserList", model);
		}

		[HttpGet]
		public IActionResult SearchAllUsers(string SearchTerm)
		{
			var globalChat = new GlobalChatViewModel
			{
				GlobalMessages = chatRepository.GetGlobalMessages()
			};

			var userModel = new UserListViewModel();
			if (SearchTerm == null || SearchTerm == "")
				userModel.Users = userRepository.GetUsers();
			else
				userModel.Users = userRepository.SearchUsers(SearchTerm);

			var model = new MultiplayerViewModel
			{
				chatModel = globalChat,
				userModel = userModel
			};

			return PartialView("AllUserList", model);
		}
	}
}