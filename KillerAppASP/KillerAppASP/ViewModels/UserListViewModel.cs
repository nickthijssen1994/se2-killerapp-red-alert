using KillerAppASP.Models;
using System.Collections.Generic;

namespace KillerAppASP.ViewModels
{
	public class UserListViewModel
	{
		public string SearchTerm { get; set; }
		public User SelectedUser { get; set; }
		public List<User> Users { get; set; }
	}
}