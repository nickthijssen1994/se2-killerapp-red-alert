using System;

namespace KillerAppASP.TestContexts
{
	public class TestUser
	{
		public int UserID { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public bool IsOnline { get; set; }
		public DateTime LastOnline { get; set; }
	}
}