using System;
using System.Collections.Generic;

namespace KillerAppASP.TestContexts
{
    public class TestUserContext : ITestUserInterface
    {
        List<TestUser> Users;

        public TestUserContext()
        {
            Users = new List<TestUser>
            {
                new TestUser() { UserID = 1, Username = "nthijssen", Password = "123456789", IsOnline = true, LastOnline = DateTime.Now},
                new TestUser() { UserID = 2, Username = "nickthijssen1994", Password = "wachtwoord", IsOnline = true, LastOnline = DateTime.Now },
                new TestUser() { UserID = 3, Username = "nickthijssen", Password = "hallohallo", IsOnline = false, LastOnline = DateTime.Now.AddDays(-1) },
                new TestUser() { UserID = 4, Username = "nthijssen1994", Password = "password123", IsOnline = false, LastOnline = DateTime.Now.AddDays(-2) },
            };
        }

        public void RegisterUser(TestUser user)
        {
            Users.Add(user);
        }

        public void LoginUser(TestUser user)
        {
            foreach (TestUser User in Users)
            {
                if (user == User)
                {
                    User.IsOnline = true;
                }
            }
        }

        public void LogoutUser(TestUser user)
        {
            foreach (TestUser User in Users)
            {
                if (user == User)
                {
                    User.IsOnline = false;
                    User.LastOnline = DateTime.Now;
                }
            }
        }

        public void ChangePassword(TestUser user, string newPassword)
        {
            foreach (TestUser User in Users)
            {
                if (user == User)
                {
                    User.Password = newPassword;
                }
            }
        }

        public void DeleteUser(TestUser user)
        {
            foreach (TestUser User in Users)
            {
                if (user == User)
                {
                    Users.Remove(User);
                }
            }
        }

        public List<TestUser> GetUsers()
        {
            return Users;
        }

        public List<TestUser> SearchUsers(string searchterm)
        {
            List<TestUser> FoundUsers = new List<TestUser>();

            foreach (TestUser User in Users)
            {
                if (User.Username.Contains(searchterm))
                {
                    FoundUsers.Add(User);
                }
            }

            return FoundUsers;
        }
    }
}