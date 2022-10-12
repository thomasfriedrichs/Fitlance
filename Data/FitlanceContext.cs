using Fitlance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Fitlance;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.Internal;

namespace Fitlance.Data
{
    public class FitlanceContext : DbContext 
    {
        public FitlanceContext(DbContextOptions<FitlanceContext> options ) 
            : base( options )
        {
        }

        public DbSet<Client>? Clients { get; set; }
        public DbSet<Trainer>? Trainers { get; set; }
        public DbSet<Appointment>? Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("FitlanceDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Fitlance");
            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Trainer>().ToTable("Trainers");
            modelBuilder.Entity<Appointment>().ToTable("Appointments");
        }
       
    }
}
