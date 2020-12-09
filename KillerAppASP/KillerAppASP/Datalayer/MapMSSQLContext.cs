using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using KillerAppASP.Interfaces;
using KillerAppASP.Models;
using Microsoft.Extensions.Configuration;

namespace KillerAppASP.Datalayer
{
	public class MapMSSQLContext : IMapContext
	{
		private readonly string connectionString = "server=localhost;database=dbredalert;uid=redalert;pwd=redalert";

		public int SaveMap(Map map, string username)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				var sqlCommand = new SqlCommand
				{
					Connection = connection,
					CommandType = CommandType.StoredProcedure,
					CommandText = "SaveMap"
				};
				sqlCommand.Parameters.AddWithValue("@Name", map.Name);
				sqlCommand.Parameters.AddWithValue("@Size", map.Size);
				sqlCommand.Parameters.AddWithValue("@Seed", map.Seed);
				sqlCommand.Parameters.AddWithValue("@GroundType", map.GroundType);
				sqlCommand.Parameters.AddWithValue("@MapType", map.MapType);
				sqlCommand.Parameters.AddWithValue("@HasLakes", map.HasLakes);
				sqlCommand.Parameters.AddWithValue("@HasRivers", map.HasRivers);
				sqlCommand.Parameters.AddWithValue("@CreationDate", map.CreationDate);
				sqlCommand.Parameters.AddWithValue("@CreatedBy", map.CreatedBy);
				sqlCommand.Parameters.AddWithValue("@Image", map.Image);

				connection.Open();
				var result = (int) sqlCommand.ExecuteScalar();
				connection.Close();
				return result;
			}
		}

		public int DeleteMap(string mapname, string username)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				var sqlCommand = new SqlCommand
				{
					Connection = connection,
					CommandType = CommandType.StoredProcedure,
					CommandText = "DeleteMap"
				};
				sqlCommand.Parameters.AddWithValue("@Name", mapname);
				sqlCommand.Parameters.AddWithValue("@Username", username);

				connection.Open();
				var result = (int) sqlCommand.ExecuteScalar();
				connection.Close();
				return result;
			}
		}

		public Map GetMap(string Name, string Username)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				var map = new Map();

				var sqlCommand = new SqlCommand
				{
					Connection = connection,
					CommandType = CommandType.StoredProcedure,
					CommandText = "GetMap"
				};
				sqlCommand.Parameters.AddWithValue("@Name", Name);
				sqlCommand.Parameters.AddWithValue("@Username", Username);

				connection.Open();
				using (var reader = sqlCommand.ExecuteReader())
				{
					while (reader.Read())
					{
						map.MapID = reader.GetInt32(0);
						map.Name = reader.GetString(1);
						map.Size = reader.GetInt32(2);
						map.Seed = reader.GetInt32(3);
						map.GroundType = reader.GetInt32(4);
						map.MapType = reader.GetInt32(5);
						map.HasLakes = reader.GetBoolean(6);
						map.HasRivers = reader.GetBoolean(7);
						map.CreationDate = reader.GetDateTime(8);
						map.CreatedBy = reader.GetString(9);
						map.Image = reader["Image"] as byte[] ?? null;
					}
				}

				connection.Close();
				return map;
			}
		}

		public List<string> GetAllMaps()
		{
			using (var connection = new SqlConnection(connectionString))
			{
				var maps = new List<string>();

				var sqlCommand = new SqlCommand
				{
					Connection = connection,
					CommandType = CommandType.StoredProcedure,
					CommandText = "GetAllMaps"
				};

				connection.Open();
				using (var reader = sqlCommand.ExecuteReader())
				{
					while (reader.Read())
					{
						var name = reader.GetString(0);
						maps.Add(name);
					}
				}

				connection.Close();
				return maps;
			}
		}

		public List<string> GetUserMaps(string username)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				var maps = new List<string>();

				var sqlCommand = new SqlCommand
				{
					Connection = connection,
					CommandType = CommandType.StoredProcedure,
					CommandText = "GetUserMaps"
				};
				sqlCommand.Parameters.AddWithValue("@Username", username);

				connection.Open();
				using (var reader = sqlCommand.ExecuteReader())
				{
					while (reader.Read())
					{
						var name = reader.GetString(0);
						maps.Add(name);
					}
				}

				connection.Close();
				return maps;
			}
		}
	}
}
