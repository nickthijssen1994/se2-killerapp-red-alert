using System.Collections.Generic;
using KillerAppASP.Models;

namespace KillerAppASP.ViewModels
{
	public class UserListViewModel
	{
		public string SearchTerm { get; set; }
		public User SelectedUser { get; set; }
		public List<User> Users { get; set; }
	}
}