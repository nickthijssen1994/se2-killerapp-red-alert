using System.Collections.Generic;
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
			Database.EnsureCreated();
			Maps.Add(map);
			SaveChanges();
			return map.MapID;
		}

		public int DeleteMap(string mapname, string username)
		{
			foreach (Map map in Maps)
			{
				if (map.Name.Equals(mapname) && map.CreatedBy.Equals(username))
				{
					Maps.Remove(map);
					SaveChanges();
					break;
				}
			}

			return 1;
		}

		public Map GetMap(string Name, string Username)
		{
			foreach (Map map in Maps)
			{
				if (map.Name.Equals(Name) && map.CreatedBy.Equals(Username))
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
			List<string> mapsString = new List<string>();
			foreach (Map map in Maps)
			{
				if (map.CreatedBy.Equals(username))
				{
					mapsString.Add(map.Name);
				}
			}

			return mapsString;
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
