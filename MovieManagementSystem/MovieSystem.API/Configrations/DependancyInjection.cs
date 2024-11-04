using Microsoft.EntityFrameworkCore;
using MovieSystem.Infrastructure.Presistance.Data;

namespace MovieSystem.API.Configrations
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DBContextApplication>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
