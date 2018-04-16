using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using KillerAppASP.Models;

namespace KillerAppASP.Data
{
    public class MapSQLContext : IMapContext
    {
        private static string databaseLocation = "Server = mssql.fhict.local; Database=dbi369786;User Id = dbi369786; Password=KillerApp";
        private SqlConnection connection = new SqlConnection(databaseLocation);

        public void SaveMap(Map map)
        {
            ArrayStringConverter converter = new ArrayStringConverter();
            string array = converter.ConvertArrayToString(map.Size, map.Tiles);
            connection.Open();
            string query = "INSERT INTO Map VALUES ('" + map.Name + "', '" + map.Size + "', '" + array + "', '" + map.Creationdate.ToString("yyyy-MM-dd") + "', '" + map.Groundtype + "', '" + map.Maptype + "', '" + map.Haslakes + "', '" + map.Hasrivers + "')";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }

        public List<Map> GetMaps()
        {
            ArrayStringConverter converter = new ArrayStringConverter();
            BitmapGenerator bitmapGenerator = new BitmapGenerator();
            List<Map> maps = new List<Map>();
            string query = "SELECT * FROM Map";
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
                    Map map = new Map(name, size, tiles, creationdate, groundtype, maptype, haslakes, hasrivers, bitmapGenerator.GenerateBitmap(tiles));
                    maps.Add(map);
                }
            }
            connection.Close();
            return maps;
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
            connection.Open();
            string query = "DELETE FROM Map WHERE Name = '" + mapname + "'";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}
