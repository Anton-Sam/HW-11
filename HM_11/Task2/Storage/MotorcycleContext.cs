using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2.Storage
{
    class ObjectContext<T> : DbContext where T: Entity
    {
        public DbSet<T> Objects { get; set; }

        public ObjectContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["LocalDBEntityFrameworkConnectionString"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
