using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Fitlance.Entities;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;

namespace Fitlance.Data;

public class FitlanceContext : IdentityDbContext<User>
{
    public FitlanceContext(DbContextOptions<FitlanceContext>  options)
        : base(options)
    {
    }

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
            modelBuilder.Entity<User>(mb =>
            {
                mb.HasMany<Appointment>().WithOne().HasForeignKey(a => a.UserId).IsRequired();
                mb.ToTable("AspNetUsers");
            });

        modelBuilder.Entity<Appointment>().ToTable("Appointments");
    }
}