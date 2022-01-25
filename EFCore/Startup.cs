using EFCore.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    public class Startup
    {
        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private IConfiguration? Configuration { get; }
        public void Configure(IApplicationBuilder app)
        {
            // Cors
            app.UseCors(
                options => options.WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowCredentials()
            );
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // enable cors
            services.AddCors(cors =>
            {
                cors.AddPolicy("allow cors", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddDbContext<TodoDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DbConnectionString"));
            });
        }
    }
}
