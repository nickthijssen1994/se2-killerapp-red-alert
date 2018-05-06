using KillerAppASP.Data;
using KillerAppASP.Models;
using System.Collections.Generic;

namespace KillerAppASP.Controllers
{
    public class AccountRepository
    {
        private IAccountContext context;

        public AccountRepository(IAccountContext context)
        {
            this.context = context;
        }

        public int RegisterUser(User user)
        {
            return context.RegisterUser(user);
        }

        public int LoginUser(User user)
        {
            return context.LoginUser(user);
        }

        public void LogoutUser(User user)
        {
            context.LogoutUser(user);
        }

        public int ChangePassword(User user, string newPassword)
        {
            return context.ChangePassword(user, newPassword);
        }

        public int DeleteUser(User user)
        {
            return context.DeleteUser(user);
        }

        public List<User> GetAllUsers()
        {
            List<User> Users = context.GetAllUsers();
            return Users;
        }

        public List<string> GetOnlineUsers()
        {
            List<string> OnlineUsers = context.GetOnlineUsers();
            return OnlineUsers;
        }

        public List<User> SearchUsers(string searchterm)
        {
            List<User> FoundUsers = context.SearchUsers(searchterm);
            FoundUsers.Sort();
            return FoundUsers;
        }
    }
}
