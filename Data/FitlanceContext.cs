using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Fitlance.Entities;

namespace Fitlance.Data;

public class FitlanceContext : IdentityDbContext
{
  public FitlanceContext(DbContextOptions<FitlanceContext> options)
      : base(options)
  {
  }

  public DbSet<User>? Users { get; set; }
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
    modelBuilder.Entity<User>().ToTable("Users");
    modelBuilder.Entity<Appointment>().ToTable("Appointments");
  }
};
