using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Application.Contracts.Service;


namespace MovieSystem.Application.Configrations
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMovieService, MovieService>();


            return services;
        }
    }
}
