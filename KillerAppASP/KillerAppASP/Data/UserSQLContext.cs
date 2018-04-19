using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using KillerAppASP.Models;

namespace KillerAppASP.Data
{
    public class UserSQLContext
    {
        private static string databaseLocation = "Server = mssql.fhict.local; Database=dbi369786;User Id = dbi369786; Password=KillerApp";
        private SqlConnection connection = new SqlConnection(databaseLocation);

        public void RegisterUser(User user)
        {
            string query = "INSERT INTO User VALUES ('" + user.Username + "', '" + user.Email + "', '" + user.Password + "')";
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            string query = "SELECT * FROM User";
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    User user = new User();
                    user.Username = reader.GetString(2);
                    users.Add(user);
                }
            }
            connection.Close();
            return users;
        }

        public List<User> GetOnlineUsers()
        {
            List<User> users = new List<User>();
            string query = "SELECT * FROM User WHERE IsOnline = 'true'";
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    User user = new User();
                    user.Username = reader.GetString(2);
                    users.Add(user);
                }
            }
            connection.Close();
            return users;
        }

        public void LoginUser(string username)
        {
            string query = "UPDATE User SET IsOnline = 'true' WHERE Username = '" + username + "'";
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void LogoutUser(string username)
        {
            string query = "UPDATE User SET IsOnline = 'false', LastOnline = '" + DateTime.Now + "' WHERE Username = '" + username + "'";
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteUser(string username)
        {
            string query = "DELETE FROM User WHERE Username = '" + username + "'";
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}
