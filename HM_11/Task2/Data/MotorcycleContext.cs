using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2.Data
{
    class ApplicationDbContext<T> : DbContext where T: Entity
    {
        public DbSet<T> Entities { get; set; }

        public ApplicationDbContext()
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
