using System.Collections.Generic;

namespace KillerAppASP.Models
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
