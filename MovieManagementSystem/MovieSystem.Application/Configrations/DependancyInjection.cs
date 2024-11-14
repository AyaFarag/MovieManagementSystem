using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MovieSystem.Application.Automapper;
using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Application.Contracts.Service;
using MovieSystem.Application.Extentions;
using MovieSystem.Application.Validation;
using System.Text;


namespace MovieSystem.Application.Configrations
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JWT>(configuration.GetSection("JwtSettings"));
            
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]))
                };
            });

            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAssignService, AssignService>();
            services.AddScoped<IAuthService, AuthService>();




            services.AddAutoMapper(typeof(MovieProfile).Assembly);
            services.AddAutoMapper(typeof(UserProfile).Assembly);


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
