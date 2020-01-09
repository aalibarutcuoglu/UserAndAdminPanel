using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using TelefonRehberi.Models.Entities;

namespace TelefonRehberi.Models.Context
{
    public class TelefonRehberiDbContext : DbContext
    {
        public TelefonRehberiDbContext()
        {
            Database.Connection.ConnectionString = "Server = ALI; Database = TelefonRehberi; Trusted_Connection = True";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<Departman> Departmanlar { get; set; }
        public DbSet<Gorev> Gorevler { get; set; }      
        public DbSet<Login> Login { get; set; }
    }
}