using KillerAppASP.Models;
using System.Collections.Generic;

namespace KillerAppASP.ViewModels
{
    public class UserListViewModel
    {
        public string SearchTerm { get; set; }
        public User SelectedUser { get; set; }
        public List<string> OnlineUsers { get; set; }
        public List<User> AllUsers { get; set; }
    }
}
