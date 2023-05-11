using Microsoft.EntityFrameworkCore;
using TaskApp.Models;

namespace TaskApp.Data
{
    public class TaskDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Database Connectivity
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=TaskDB;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // seed some basic data 
            // administrator user in the user table

            //modelBuilder.SeedDefaultData();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Taskm> Taskms { get; set; }
    }
}