using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using KillerAppASP.Interfaces;
using KillerAppASP.Models;
using Microsoft.EntityFrameworkCore;

namespace KillerAppASP.Datalayer
{
	public class UserMSSQLContext : DbContext, IUserContext
	{
		private readonly string connectionString = "server=localhost;database=dbredalert;uid=redalert;pwd=redalert";
		public DbSet<User> Users { get; set; }

		public int RegisterUser(User user)
		{
			user.LastOnline = DateTime.Now;
			// Creates the database if not exists
			Database.EnsureCreated();
			Users.Add(user);
			// Saves changes
			SaveChanges();
			return user.UserID;
		}

		public int LoginUser(User user)
		{
			Database.EnsureCreated();
			foreach (var registeredUser in Users)
			{
				if (user.Username.Equals(registeredUser.Username) && user.Password.Equals(registeredUser.Username))
				{
					registeredUser.IsOnline = true;
					Users.Update(registeredUser);
					SaveChanges();
					return 0;
				}
			}
			return 0;
		}

		public void LogoutUser(User user)
		{
			Database.EnsureCreated();
			foreach (var registeredUser in Users)
			{
				if (user.Username.Equals(registeredUser.Username) && user.Password.Equals(registeredUser.Username))
				{
					registeredUser.IsOnline = false;
					registeredUser.LastOnline = DateTime.Now;
					Users.Update(registeredUser);
					SaveChanges();
				}
			}
		}

		public int ChangePassword(User user, string newPassword)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				var sqlCommand = new SqlCommand
				{
					Connection = connection,
					CommandType = CommandType.StoredProcedure,
					CommandText = "ChangePassword"
				};
				sqlCommand.Parameters.AddWithValue("@Username", user.Username);
				sqlCommand.Parameters.AddWithValue("@OldPassword", user.Password);
				sqlCommand.Parameters.AddWithValue("@NewPassword", newPassword);

				connection.Open();
				var result = (int) sqlCommand.ExecuteScalar();
				connection.Close();
				return result;
			}
		}

		public int DeleteUser(User user)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				var sqlCommand = new SqlCommand
				{
					Connection = connection,
					CommandType = CommandType.StoredProcedure,
					CommandText = "DeleteUser"
				};
				sqlCommand.Parameters.AddWithValue("@Username", user.Username);
				sqlCommand.Parameters.AddWithValue("@Password", user.Password);

				connection.Open();
				var result = (int) sqlCommand.ExecuteScalar();
				connection.Close();
				return result;
			}
		}

		public List<User> GetUsers()
		{
			return Users.ToList();
		}

		public List<User> SearchUsers(string searchterm)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				var foundUsers = new List<User>();

				var sqlCommand = new SqlCommand
				{
					Connection = connection,
					CommandType = CommandType.StoredProcedure,
					CommandText = "SearchUsers"
				};
				sqlCommand.Parameters.AddWithValue("@SearchTerm", searchterm);

				connection.Open();
				using (var reader = sqlCommand.ExecuteReader())
				{
					while (reader.Read())
					{
						var foundUser = new User
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

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySQL(connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>(entity =>
			{
				entity.HasKey(e => e.UserID);
				entity.Property(e => e.Username).IsRequired();
				entity.Property(e => e.Email).IsRequired();
				entity.Property(e => e.Password).IsRequired();
			});
		}
	}
}
