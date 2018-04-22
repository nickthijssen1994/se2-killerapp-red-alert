using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using KillerAppASP.Models;

namespace KillerAppASP.Data
{
    public class AccountSQLContext : IAccountContext
    {
        private static string databaseLocation = "Server = mssql.fhict.local; Database=dbi369786;User Id = dbi369786; Password=KillerApp";
        private SqlConnection connection = new SqlConnection(databaseLocation);
        private SqlCommand sqlCommand = new SqlCommand();

        public bool RegisterUser(User user)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "RegisterUser";
            sqlCommand.Parameters.AddWithValue("@Email", user.Username);
            sqlCommand.Parameters.AddWithValue("@Username", user.Username);
            sqlCommand.Parameters.AddWithValue("@Password", user.Password);
            sqlCommand.Connection = connection;
            connection.Open();
            bool RegistrationSuccessfull = (bool)sqlCommand.ExecuteScalar();
            connection.Close();
            return RegistrationSuccessfull;
        }

        public bool LoginUser(User user)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "LoginUser";
            sqlCommand.Parameters.AddWithValue("@Username", user.Username);
            sqlCommand.Parameters.AddWithValue("@Password", user.Password);
            sqlCommand.Connection = connection;
            connection.Open();
            bool LoginSuccessfull = (bool)sqlCommand.ExecuteScalar();
            connection.Close();
            return LoginSuccessfull;
        }

        public void LogoutUser(User user)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "LogoutUser";
            sqlCommand.Parameters.AddWithValue("@Username", user.Username);
            sqlCommand.Connection = connection;
            connection.Open();
            sqlCommand.ExecuteScalar();
            connection.Close();
        }

        public bool DeleteUser(User user)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "DeleteUser";
            sqlCommand.Parameters.AddWithValue("@Username", user.Username);
            sqlCommand.Parameters.AddWithValue("@Password", user.Password);
            sqlCommand.Connection = connection;
            connection.Open();
            bool DeletionSuccessfull = (bool)sqlCommand.ExecuteScalar();
            connection.Close();
            return DeletionSuccessfull;
        }

        public List<string> GetAllUsers()
        {
            List<string> Users = new List<string>();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "GetAllUsers";
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Users.Add(reader.GetString(0));
                }
            }
            connection.Close();
            return Users;
        }

        public List<string> GetOnlineUsers()
        {
            List<string> OnlineUsers = new List<string>();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "GetOnlineUsers";
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    OnlineUsers.Add(reader.GetString(0));
                }
            }
            connection.Close();
            return OnlineUsers;
        }

        public List<string> SearchUsers (string searchterm)
        {
            List<string> FoundUsers = new List<string>();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "SearchUser";
            sqlCommand.Parameters.AddWithValue("@SearchTerm", searchterm);
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    FoundUsers.Add(reader.GetString(0));
                }
            }
            connection.Close();
            return FoundUsers;
        }
    }
}
