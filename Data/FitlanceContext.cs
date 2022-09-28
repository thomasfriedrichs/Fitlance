using Fitlance.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Fitlance.Data
{
    public class FitlanceContext : DbContext 
    {
        public FitlanceContext(DbContextOptions<FitlanceContext> options ) 
            : base( options )
        {
            
        }

        public DbSet<Client>? Clients { get; set; }

       
    }
}
