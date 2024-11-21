using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieSystem.Domain.Entities;
using MovieSystem.Infrastructure.Presistance.Models;

namespace MovieSystem.Infrastructure.Presistance.Data
{
    public class DBContextApplication : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DBContextApplication(DbContextOptions<DBContextApplication> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Rename Identity tables
            builder.Entity<ApplicationUser>().ToTable("Users"); // class
            builder.Entity<ApplicationRole>().ToTable("Roles"); // class
            builder.Entity<Permission>().ToTable("Permissions"); // class and table
            builder.Entity<UserRole>().ToTable("UserRole"); // class
            builder.Entity<UserPermission>().ToTable("UserPermission"); // class
            builder.Entity<RolePermission>().ToTable("RolePermission"); // class
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken");

            // Define seed data
            var adminRoleId = Guid.NewGuid().ToString();
            var userRoleId = Guid.NewGuid().ToString();
            var adminUserId = Guid.NewGuid().ToString();

            // Seed Roles
            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
                new ApplicationRole { Id = userRoleId, Name = "User", NormalizedName = "USER" }
            );

            // Seed Users (Admin)
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = adminUserId,
                    Name = "admin",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin@123")
                }
            );

            // Seed UserRoles
            builder.Entity<UserRole>().HasData(
                new UserRole { UserId = adminUserId, RoleId = adminRoleId }
            );

            // Seed Permissions
            builder.Entity<Permission>().HasData(
                new Permission { Id = 1, Name = "ViewRecords" },
                new Permission { Id = 2, Name = "EditRecords" },
                new Permission { Id = 3, Name = "DeleteRecords" }
            );

            // Seed UserPermissions
            builder.Entity<UserPermission>().HasData(
                new UserPermission { Id = 1, UserId = adminUserId, ClaimType = "Permission", ClaimValue = "ViewRecords" },
                new UserPermission { Id = 2, UserId = adminUserId, ClaimType = "Permission", ClaimValue = "EditRecords" }
            );

            // Seed RolePermissions
            builder.Entity<RolePermission>().HasData(
                new RolePermission { Id = 1, RoleId = adminRoleId, ClaimType = "Permission", ClaimValue = "ViewRecords" },
                new RolePermission { Id = 2, RoleId = adminRoleId, ClaimType = "Permission", ClaimValue = "EditRecords" },
                new RolePermission { Id = 3, RoleId = adminRoleId, ClaimType = "Permission", ClaimValue = "DeleteRecords" }
            );
          //  builder.Entity<UserMovies>().HasKey(um => new { um.movieId, um.userId });

            //builder.Entity<User>()
            //  .HasMany(u => u.Roles)
            //  .WithMany(r => r.Users)
            //  .UsingEntity<Dictionary<string, object>>(
            //      "RoleUser",  // Join table name
            //      j => j.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
            //      j => j.HasOne<User>().WithMany().HasForeignKey("UserId"));
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
      
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserMovies> UserMovies { get; set; }





    }
}
