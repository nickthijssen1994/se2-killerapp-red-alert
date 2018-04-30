using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using KillerAppASP.Models;
using Microsoft.Extensions.Configuration;

namespace KillerAppASP.Data
{
    public class AccountSQLContext : IAccountContext
    {
        private readonly string connectionString = Program.Configuration.GetConnectionString("DefaultConnection");

        public bool RegisterUser(User user)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "RegisterUser"
                        
                    };
                    sqlCommand.Parameters.AddWithValue("@Email", user.Email);
                    sqlCommand.Parameters.AddWithValue("@Username", user.Username);
                    sqlCommand.Parameters.AddWithValue("@Password", user.Password);
                    connection.Open();
                    bool RegistrationSuccessfull = (bool)sqlCommand.ExecuteScalar();
                    connection.Close();
                    return RegistrationSuccessfull;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool LoginUser(User user)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "LoginUser"
                    };
                    sqlCommand.Parameters.AddWithValue("@Username", user.Username);
                    sqlCommand.Parameters.AddWithValue("@Password", user.Password);
                    connection.Open();
                    bool LoginSuccessfull = (bool)sqlCommand.ExecuteScalar();
                    connection.Close();
                    return LoginSuccessfull;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LogoutUser(User user)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "LogoutUser"
                    };                 
                    sqlCommand.Parameters.AddWithValue("@Username", user.Username);
                    connection.Open();
                    sqlCommand.ExecuteScalar();
                    connection.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteUser(User user)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "DeleteUser"
                    };
                    sqlCommand.Parameters.AddWithValue("@Username", user.Username);
                    sqlCommand.Parameters.AddWithValue("@Password", user.Password);
                    connection.Open();
                    bool DeletionSuccessfull = (bool)sqlCommand.ExecuteScalar();
                    connection.Close();
                    return DeletionSuccessfull;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<string> GetAllUsers()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    List<string> Users = new List<string>();
                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "GetAllUsers"
                    };
                    connection.Open();
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
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<string> GetOnlineUsers()
        { 
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    List<string> OnlineUsers = new List<string>();
                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "GetOnlineUsers"
                    };
                    connection.Open();
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
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<string> SearchUsers(string searchterm)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    List<string> FoundUsers = new List<string>();
                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "SearchUser"
                    };
                    sqlCommand.Parameters.AddWithValue("@SearchTerm", searchterm);
                    connection.Open();
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
            catch (Exception)
            {
                throw;
            }
        }
    }
}
