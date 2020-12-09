using System.Collections.Generic;

namespace KillerAppASP.TestContexts
{
	public class TestUserRepository
	{
		private readonly ITestUserInterface context;
		public List<TestUser> FoundUsers;
		public TestUser User;
		public List<TestUser> Users;

		public TestUserRepository(ITestUserInterface context)
		{
			this.context = context;
			Users = context.GetUsers();
		}

		public void RegisterUser(TestUser User)
		{
			context.RegisterUser(User);
		}

		public void LoginUser(string Username, string Password)
		{
			context.LoginUser(User);
		}

		public void LogoutUser(TestUser User)
		{
			context.LogoutUser(User);
		}

		public void ChangePassword(TestUser User, string NewPassword)
		{
			context.ChangePassword(User, NewPassword);
		}

		public void DeleteUser(TestUser User)
		{
			context.DeleteUser(User);
		}

		public void GetUsers()
		{
			Users = context.GetUsers();
		}

		public void SearchUsers(string SearchTerm)
		{
			if (SearchTerm == "")
				FoundUsers = Users;
			else
				FoundUsers = context.SearchUsers(SearchTerm);
		}
	}
}