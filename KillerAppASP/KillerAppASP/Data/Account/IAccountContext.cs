using KillerAppASP.Models;
using System.Collections.Generic;

namespace KillerAppASP.Data
{
    public interface IAccountContext
    {
        bool RegisterUser(User user);
        bool LoginUser(User user);
        void LogoutUser(User user);
        bool DeleteUser(User user);
        List<string> GetAllUsers();
        List<string> GetOnlineUsers();
        List<string> SearchUsers(string searchterm);
    }
}
