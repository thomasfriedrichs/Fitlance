using Fitlance.Data;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Fitlance
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FitlanceContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("FitlanceDB")));
            services.AddControllers();
        }
        
        public void Configure(IApplicationBuilder app)
        {
        }
    }
}
