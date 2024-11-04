using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieSystem.Domain.Entities;

namespace MovieSystem.Infrastructure.Presistance.Data
{
    public class DBContextApplication : DbContext
    {
        public DBContextApplication(DbContextOptions<DBContextApplication> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<User>()
              .HasMany(u => u.Roles)
              .WithMany(r => r.Users)
              .UsingEntity<Dictionary<string, object>>(
                  "RoleUser",  // Join table name
                  j => j.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                  j => j.HasOne<User>().WithMany().HasForeignKey("UserId"));
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Review> Reviews { get; set; }





    }
}
