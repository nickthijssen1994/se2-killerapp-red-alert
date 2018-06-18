using KillerAppASP.Interfaces;
using KillerAppASP.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace KillerAppASP.Datalayer
{
    public class ChatMSSQLContext : IChatContext
    {
        private readonly string connectionString = Program.Configuration.GetConnectionString("DefaultConnection");

        public void SendGlobalMessage(Message message)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "SendGlobalMessage"
                    };
                    sqlCommand.Parameters.AddWithValue("@SendBy", message.SendBy);
                    sqlCommand.Parameters.AddWithValue("@Text", message.Text);
                    sqlCommand.Parameters.AddWithValue("@TimeStamp", message.TimeStamp);
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

        public List<Message> GetGlobalMessages()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    List<Message> globalMessages = new List<Message>();

                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "GetGlobalMessages"
                    };

                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Message message = new Message
                            {
                                MessageID = reader.GetInt32(0),
                                SendBy = reader.GetString(1),
                                Text = reader.GetString(2),
                                TimeStamp = reader.GetDateTime(3)
                            };
                            globalMessages.Add(message);
                        }
                    }
                    connection.Close();
                    return globalMessages;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}