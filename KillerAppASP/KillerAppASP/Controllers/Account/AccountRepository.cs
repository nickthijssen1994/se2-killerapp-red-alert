using System.Collections.Generic;
using KillerAppASP.Data;
using KillerAppASP.Models;

namespace KillerAppASP.Controllers
{
    public class AccountRepository
    {
        private readonly IAccountContext _accountcontext;

        public AccountRepository(IAccountContext accountcontext)
        {
            _accountcontext = accountcontext;
        }

        public bool DeleteUser(User user)
        {
            bool DeletionSuccessfull = _accountcontext.DeleteUser(user);
            return DeletionSuccessfull;
        }

        public bool LoginUser(User user)
        {
            bool LoginSuccessfull = _accountcontext.LoginUser(user);
            return LoginSuccessfull;
        }

        public void LogoutUser(User user)
        {
            _accountcontext.LogoutUser(user);
        }

        public bool RegisterUser(User user)
        {
            bool RegistrationSuccessfull = _accountcontext.RegisterUser(user);
            return RegistrationSuccessfull;
        }

        public List<string> GetAllUsers()
        {
            List<string> AllUsers = _accountcontext.GetAllUsers();
            return AllUsers;
        }

        public List<string> GetOnlineUsers()
        {
            List<string> OnlineUsers = _accountcontext.GetOnlineUsers();
            return OnlineUsers;
        }

        public List<string> SearchUsers(string searchterm)
        {
            List<string> FoundUsers = _accountcontext.SearchUsers(searchterm);
            return FoundUsers;
        }
    }
}
