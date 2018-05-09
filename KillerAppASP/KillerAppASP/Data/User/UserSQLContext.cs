using KillerAppASP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace KillerAppASP.Data
{
    public class UserSQLContext : SQLContext, IUserContext
    {
        public int RegisterUser(User user)
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
                    sqlCommand.Parameters.AddWithValue("@AutoLogin", user.IsOnline);

                    connection.Open();
                    int result = (int)sqlCommand.ExecuteScalar();
                    connection.Close();
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int LoginUser(User user)
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
                    int result = (int)sqlCommand.ExecuteScalar();
                    connection.Close();
                    return result;
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

        public int ChangePassword(User user, string newPassword)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "ChangePassword"
                    };
                    sqlCommand.Parameters.AddWithValue("@Username", user.Username);
                    sqlCommand.Parameters.AddWithValue("@OldPassword", user.Password);
                    sqlCommand.Parameters.AddWithValue("@NewPassword", newPassword);

                    connection.Open();
                    int result = (int)sqlCommand.ExecuteScalar();
                    connection.Close();
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int DeleteUser(User user)
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
                    int result = (int)sqlCommand.ExecuteScalar();
                    connection.Close();
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<User> GetUsers()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    List<User> users = new List<User>();
                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "GetUsers"
                    };

                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User
                            {
                                UserID = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                IsOnline = reader.GetBoolean(2),
                                LastOnline = reader.GetDateTime(3)
                            };
                            users.Add(user);
                        }
                    }
                    connection.Close();
                    return users;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<User> SearchUsers(string searchterm)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    List<User> foundUsers = new List<User>();

                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "SearchUsers"
                    };
                    sqlCommand.Parameters.AddWithValue("@SearchTerm", searchterm);

                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User foundUser = new User
                            {
                                UserID = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                IsOnline = reader.GetBoolean(2),
                                LastOnline = reader.GetDateTime(3)
                            };
                            foundUsers.Add(foundUser);
                        }
                    }
                    connection.Close();
                    return foundUsers;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
