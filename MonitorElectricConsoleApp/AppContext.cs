using Microsoft.EntityFrameworkCore;
using MonitorElectricConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitorElectricConsoleApp
{
    public class AppContext : DbContext
    {
        public DbSet<Result> Results { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=local.db");
        }
    }
}
