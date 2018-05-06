using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace KillerAppASP.Data
{
    public class SQLContext
    {
        protected readonly string connectionString = Program.Configuration.GetConnectionString("DefaultConnection");
        private List<KeyValuePair<string, object>> ProcedureParameters = new List<KeyValuePair<string, object>>();
        private List<KeyValuePair<object, string>> ReaderValues = new List<KeyValuePair<object, string>>();
        private string StoredProcedure = "";

        protected void AddParameter(string Name, object Value)
        {
            ProcedureParameters.Add(new KeyValuePair<string, object>(Name, Value));
        }

        protected void AddValue(object Value, string ColumnName)
        {
            ReaderValues.Add(new KeyValuePair<object, string>(Value, ColumnName));
        }

        protected object Command(Action action)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = StoredProcedure
                    };

                    foreach (KeyValuePair<string, object> Parameter in ProcedureParameters)
                    {
                        sqlCommand.Parameters.AddWithValue(Parameter.Key, Parameter.Value);
                    }

                    connection.Open();
                    object result = action;
                    connection.Close();
                    ProcedureParameters.Clear();
                    ReaderValues.Clear();
                    StoredProcedure = "";
                    return result;
                }
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
        }

        protected List<object> Select(string StoredProcedure)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = StoredProcedure
                    };
                    foreach (object Parameter in ProcedureParameters)
                    {
                        sqlCommand.Parameters.Add(Parameter);
                    }
                    List<object> list = new List<object>();
                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            object item = new object();
                            list.Add(item);
                        }
                    }
                    connection.Close();
                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected string Insert(string StoredProcedure)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = StoredProcedure
                    };
                    foreach (KeyValuePair<string, object> Parameter in ProcedureParameters)
                    {
                        sqlCommand.Parameters.AddWithValue(Parameter.Key, Parameter.Value);
                    }
                    connection.Open();
                    string result = sqlCommand.ExecuteScalar().ToString();
                    connection.Close();
                    ProcedureParameters.Clear();
                    ReaderValues.Clear();
                    StoredProcedure = "";
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected string Update(string StoredProcedure)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = StoredProcedure
                    };
                    foreach (object Parameter in ProcedureParameters)
                    {
                        sqlCommand.Parameters.Add(Parameter);
                    }
                    connection.Open();
                    string result = sqlCommand.ExecuteScalar().ToString();
                    connection.Close();
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected string Delete(string StoredProcedure)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = StoredProcedure
                    };
                    foreach (object Parameter in ProcedureParameters)
                    {
                        sqlCommand.Parameters.Add(Parameter);
                    }
                    connection.Open();
                    string result = sqlCommand.ExecuteScalar().ToString();
                    connection.Close();
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
