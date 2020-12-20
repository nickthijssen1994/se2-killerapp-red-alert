using KillerAppASP.Interfaces;
using KillerAppASP.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace KillerAppASP.Datalayer
{
    public class ChatMSSQLContext : DbContext, IChatContext
    {
        private readonly string connectionString = "server=localhost;database=dbredalert;uid=redalert;pwd=redalert";
        
        public DbSet<Message> Messages { get; set; }

        public void SendGlobalMessage(Message message)
        {
            Database.EnsureCreated();
            Messages.Add(message);
            SaveChanges();
        }

        public List<Message> GetGlobalMessages()
        {
            return Messages.ToList();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.MessageID);
                entity.Property(e => e.SendBy).IsRequired();
                entity.Property(e => e.Text).IsRequired();
                entity.Property(e => e.TimeStamp).IsRequired();
            });
        }
    }
}
