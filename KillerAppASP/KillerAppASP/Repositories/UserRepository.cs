using KillerAppASP.Helperclasses;
using KillerAppASP.Interfaces;
using KillerAppASP.Models;
using System.Collections.Generic;
using KillerAppASP.Datalayer;

namespace KillerAppASP.Repositories
{
    public class UserRepository
    {
        private IUserContext context;

        public UserRepository(IUserContext context)
        {
            this.context = context;
            using(var mysqlContext = new UserMSSQLContext())
            {
                // Creates the database if not exists
                mysqlContext.Database.EnsureCreated();
                mysqlContext.SaveChanges();
            }
        }

        public int RegisterUser(User user)
        {
            user.Password = PasswordEncryptor.EncryptPassword(user.Password);
            return context.RegisterUser(user);
        }

        public int LoginUser(User user)
        {
            user.Password = PasswordEncryptor.EncryptPassword(user.Password);
            return context.LoginUser(user);
        }

        public void LogoutUser(User user)
        {
            context.LogoutUser(user);
        }

        public int ChangePassword(User user, string newPassword)
        {
            user.Password = PasswordEncryptor.EncryptPassword(user.Password);
            newPassword = PasswordEncryptor.EncryptPassword(newPassword);
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
