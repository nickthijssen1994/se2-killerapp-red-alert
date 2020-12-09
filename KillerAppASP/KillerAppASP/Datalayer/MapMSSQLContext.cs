using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using KillerAppASP.Interfaces;
using KillerAppASP.Models;
using Microsoft.EntityFrameworkCore;

namespace KillerAppASP.Datalayer
{
	public class MapMSSQLContext : DbContext, IMapContext
	{
		private readonly string connectionString = "server=localhost;database=dbredalert;uid=redalert;pwd=redalert";

		public DbSet<Map> Maps { get; set; }
		
		public int SaveMap(Map map, string username)
		{
			map.CreatedBy = username;
			// Creates the database if not exists
			Database.EnsureCreated();
			Maps.Add(map);
			// Saves changes
			SaveChanges();
			return map.MapID;
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
			foreach (Map map in Maps)
			{
				if (map.Name.Equals(Name))
				{
					return map;
				}
			}

			return null;
		}

		public List<string> GetAllMaps()
		{
			
			List<string> mapsString = new List<string>();
			foreach (Map map in Maps)
			{
				mapsString.Add(map.Name);
			}
			return mapsString;
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
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySQL(connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Map>(entity =>
			{
				entity.HasKey(e => e.MapID);
				entity.Property(e => e.Name).IsRequired();
				entity.Property(e => e.Size).IsRequired();
				entity.Property(e => e.Seed).IsRequired();
			});
		}
	}
}
