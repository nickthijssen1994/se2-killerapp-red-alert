using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using KillerAppASP.Models;
using Microsoft.Extensions.Configuration;

namespace KillerAppASP.Data
{
    public class MapSQLContext : IMapContext
    {
        private static string databaseLocation = Program.Configuration.GetConnectionString("DefaultConnection");
        private SqlConnection connection = new SqlConnection(databaseLocation);

        public void SaveMap(Map map)
        {
            ArrayStringConverter converter = new ArrayStringConverter();
            string array = converter.ConvertArrayToString(map.Size, map.Tiles);
            try
            {
                using (var connection = new SqlConnection(databaseLocation))
                {
                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "SaveMap"
                    };
                    sqlCommand.Parameters.AddWithValue("@Name", map.Name);
                    sqlCommand.Parameters.AddWithValue("@Size", map.Size);
                    sqlCommand.Parameters.AddWithValue("@Array", array);
                    sqlCommand.Parameters.AddWithValue("@GroundType", map.Groundtype);
                    sqlCommand.Parameters.AddWithValue("@MapType", map.Maptype);
                    sqlCommand.Parameters.AddWithValue("@HasLakes", map.Haslakes);
                    sqlCommand.Parameters.AddWithValue("@HasRivers", map.Hasrivers);
                    sqlCommand.Parameters.AddWithValue("@CreationDate", map.Creationdate);
                    sqlCommand.Parameters.AddWithValue("@CreatedBy", "nthijssen");
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Map> GetMaps()
        {
            ArrayStringConverter converter = new ArrayStringConverter();
            BitmapGenerator bitmapGenerator = new BitmapGenerator();
            List<Map> maps = new List<Map>();
            try
            {
                using (var connection = new SqlConnection(databaseLocation))
                {
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
                            string name = reader.GetString(1);
                            int size = reader.GetInt32(2);
                            int[,] tiles = converter.ConvertStringToArray(size, reader.GetString(3));
                            int groundtype = reader.GetInt32(4);
                            int maptype = reader.GetInt32(5);
                            bool haslakes = reader.GetBoolean(6);
                            bool hasrivers = reader.GetBoolean(7);
                            DateTime creationdate = reader.GetDateTime(8);
                            Map map = new Map(name, size, tiles, creationdate, groundtype, maptype, haslakes, hasrivers, bitmapGenerator.GenerateBitmap(tiles));
                            maps.Add(map);
                        }
                    }
                    connection.Close();
                }
                return maps;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Map GetMap(string mapname)
        {
            ArrayStringConverter converter = new ArrayStringConverter();
            BitmapGenerator bitmapGenerator = new BitmapGenerator();
            Map map = null;
            string query = "SELECT * FROM Map WHERE Name= '" + mapname + "'";
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    string name = reader.GetString(1);
                    int size = reader.GetInt32(2);
                    int[,] tiles = converter.ConvertStringToArray(size, reader.GetString(3));
                    DateTime creationdate = reader.GetDateTime(4);
                    int groundtype = reader.GetInt32(5);
                    int maptype = reader.GetInt32(6);
                    bool haslakes = reader.GetBoolean(7);
                    bool hasrivers = reader.GetBoolean(8);
                    map = new Map(name, size, tiles, creationdate, groundtype, maptype, haslakes, hasrivers, bitmapGenerator.GenerateBitmap(tiles));
                }
            }
            connection.Close();
            return map;
        }

        public void DeleteMap(string mapname)
        {
            string query = "DELETE FROM Map WHERE Name = '" + mapname + "'";
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}
