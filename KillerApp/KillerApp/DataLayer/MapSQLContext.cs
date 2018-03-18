using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace KillerApp.DataLayer
{
    public class MapSQLContext : IMapContext
    {
        private static string databaseLocation = "Server = mssql.fhict.local; Database=dbi369786;User Id = dbi369786; Password=KillerApp";
        private SqlConnection connection = new SqlConnection(databaseLocation);

        public void AddMap(Map map)
        {
            connection.Open();
            string query = "INSERT INTO Maps VALUES ('" + map.Name + "', '" + map.Size + "', '" + map.Tiles + "', '" + map.Creationdate + "', '" + map.Groundtype + "', '" + map.Maptype + "')";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            connection.Close();
        }

        public List<Map> GetMaps()
        {
            List<Map> maps = new List<Map>();
            string query = "SELECT * FROM Maps";
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    string name = reader.GetString(1);
                    int size = reader.GetInt32(2);
                    string tiles = reader.GetString(3);
                    DateTime creationdate = reader.GetDateTime(4);
                    int groundtype = reader.GetInt32(5);
                    int maptype = reader.GetInt32(6);
                    Map map = new Map(name, size, tiles, creationdate, groundtype, maptype);
                    maps.Add(map);
                }
            }
            connection.Close();
            return maps;
        }

        public Map GetMap(string mapname)
        {
            Map map = null;
            string query = "SELECT * FROM Maps WHERE Name= '" + mapname + "'";
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    string name = reader.GetString(1);
                    int size = reader.GetInt32(2);
                    string tiles = reader.GetString(3);
                    DateTime creationdate = reader.GetDateTime(4);
                    int groundtype = reader.GetInt32(5);
                    int maptype = reader.GetInt32(6);
                    map = new Map(name, size, tiles, creationdate, groundtype, maptype);
                }
            }
            connection.Close();
            return map;
        }

        public void DeleteMap(string mapname)
        {
            connection.Open();
            string query = "DELETE FROM Maps WHERE Name = '" + mapname + "'";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            connection.Close();
        }
    }
}
