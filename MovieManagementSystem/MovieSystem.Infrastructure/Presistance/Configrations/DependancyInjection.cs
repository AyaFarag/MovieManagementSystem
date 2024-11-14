using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using MovieSystem.Application.Repository.Interface;
using MovieSystem.Infrastructure.Automapper;
using MovieSystem.Infrastructure.Presistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Infrastructure.Presistance.Configrations
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAssignRepository, AssignRepository>();

            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }

        public static WebApplication UseInfrastructureServices(this WebApplication app)
        {


            return app;
        }
    }
}
