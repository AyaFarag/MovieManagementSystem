using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieSystem.Application.Automapper;
using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Application.Contracts.Service;
using MovieSystem.Application.Validation;


namespace MovieSystem.Application.Configrations
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAssignService, AssignService>();



            services.AddAutoMapper(typeof(MovieProfile).Assembly);

            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddAutoMapper(typeof(Program));

            // Register FluentValidation
            services.AddValidatorsFromAssemblyContaining<MovieValidator>();
            //services.AddValidatorsFromAssemblyContaining<ReviewValidator>();


            // Add FluentValidation to MVC
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            return services;
        }
    }
}
