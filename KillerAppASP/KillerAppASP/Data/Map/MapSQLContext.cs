using KillerAppASP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace KillerAppASP.Data
{
    public class MapSQLContext : SQLContext, IMapContext
    {
        public int SaveMap(Map map, string username)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "SaveMap"
                    };
                    ArrayStringConverter converter = new ArrayStringConverter();
                    string array = converter.ConvertArrayToString(map.Size, map.Array);
                    sqlCommand.Parameters.AddWithValue("@Name", map.Name);
                    sqlCommand.Parameters.AddWithValue("@Size", map.Size);
                    sqlCommand.Parameters.AddWithValue("@Array", array);
                    sqlCommand.Parameters.AddWithValue("@GroundType", map.GroundType);
                    sqlCommand.Parameters.AddWithValue("@MapType", map.MapType);
                    sqlCommand.Parameters.AddWithValue("@HasLakes", map.HasLakes);
                    sqlCommand.Parameters.AddWithValue("@HasRivers", map.HasRivers);
                    sqlCommand.Parameters.AddWithValue("@CreationDate", map.CreationDate);
                    sqlCommand.Parameters.AddWithValue("@CreatedBy", username);

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

        public int DeleteMap(string mapname, string username)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "DeleteMap"
                    };
                    sqlCommand.Parameters.AddWithValue("@Name", mapname);
                    sqlCommand.Parameters.AddWithValue("@Username", username);

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

        public List<string> GetAllMaps()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    ArrayStringConverter converter = new ArrayStringConverter();
                    List<string> maps = new List<string>();

                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "GetAllMaps"
                    };

                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            maps.Add(name);
                        }
                    }
                    connection.Close();
                    return maps;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<string> GetUserMaps(string username)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    ArrayStringConverter converter = new ArrayStringConverter();
                    List<string> maps = new List<string>();

                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "GetUserMaps"
                    };
                    sqlCommand.Parameters.AddWithValue("@Username", username);

                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            maps.Add(name);
                        }
                    }
                    connection.Close();
                    return maps;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
