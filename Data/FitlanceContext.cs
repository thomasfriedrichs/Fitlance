using Fitlance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Fitlance.Entities;

namespace Fitlance.Data;

public class FitlanceContext : IdentityDbContext<User>
{
  public FitlanceContext(DbContextOptions<FitlanceContext> options)
      : base(options)
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
    base.OnModelCreating(modelBuilder);

    modelBuilder.HasDefaultSchema("Fitlance");
    modelBuilder.Entity<Client>().ToTable("Clients");
    modelBuilder.Entity<Trainer>().ToTable("Trainers");
    modelBuilder.Entity<Appointment>().ToTable("Appointments");
    //modelBuilder.Entity<User>().ToTable("Users");
  }
};
