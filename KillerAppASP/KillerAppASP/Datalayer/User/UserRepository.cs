using KillerAppASP.Models;
using System.Collections.Generic;

namespace KillerAppASP.Datalayer
{
    public class UserRepository
    {
        private IUserContext context;

        public UserRepository(IUserContext context)
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

        public List<User> GetUsers()
        {
            List<User> Users = context.GetUsers();
            return Users;
        }

        public List<User> SearchUsers(string searchterm)
        {
            List<User> FoundUsers = context.SearchUsers(searchterm);
            return FoundUsers;
        }
    }
}
