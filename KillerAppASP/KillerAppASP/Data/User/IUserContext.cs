using KillerAppASP.Models;
using System.Collections.Generic;

namespace KillerAppASP.Data
{
    public interface IUserContext
    {
        int RegisterUser(User user);
        int LoginUser(User user);
        void LogoutUser(User user);
        int ChangePassword(User user, string newPassword);
        int DeleteUser(User user);
        List<User> GetUsers();
        List<User> SearchUsers(string searchterm);
    }
}
