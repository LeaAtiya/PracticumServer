using Factory.Core.Entities;
using Factory.Entities;
using Microsoft.EntityFrameworkCore;

namespace Factory.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Worker> workers { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<RoleToWorker> rolesToWorkers { get; set; }

    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=factory_db;Integrated Security=true");
        }
    }
}
