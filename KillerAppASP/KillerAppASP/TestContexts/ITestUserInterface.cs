using System.Collections.Generic;

namespace KillerAppASP.TestContexts
{
    public interface ITestUserInterface
    {
        void RegisterUser(TestUser User);
        void LoginUser(TestUser User);
        void LogoutUser(TestUser User);
        void ChangePassword(TestUser User, string NewPassword);
        void DeleteUser(TestUser User);
        List<TestUser> GetUsers();
        List<TestUser> SearchUsers(string SearchTerm);
    }
}