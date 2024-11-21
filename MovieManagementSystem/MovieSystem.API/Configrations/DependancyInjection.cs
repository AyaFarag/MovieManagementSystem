using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieSystem.Domain.Entities;
using MovieSystem.Infrastructure.Presistance.Data;
using MovieSystem.Infrastructure.Presistance.Models;
using System;

namespace MovieSystem.API.Configrations
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DBContextApplication>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";  // Replace with your Redis server configuration
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DBContextApplication>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
