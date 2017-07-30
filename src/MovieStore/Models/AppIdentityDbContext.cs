using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace MovieStore.Models
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
        : base(options) { }

        public static async Task CreateAdminAccount(IServiceProvider serviceProvider,
        IConfiguration configuration)
        {
            UserManager<AppUser> userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> roleManager =
            serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string username = configuration["Data:AdminUser:Name"];
            string email = configuration["Data:AdminUser:Email"];
            string password = configuration["Data:AdminUser:Password"];
            string role = configuration["Data:AdminUser:Role"];
            if (await userManager.FindByNameAsync(username) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                AppUser user = new AppUser
                {
                    UserName = username,
                    Email = email
                };

                IdentityResult result = await userManager .CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }

        // Payment Table with Rental Table
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<AppUserMovies> UserMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*
            // User to Payment - 1 to M relation
            modelBuilder.Entity<AppUser>()
                .HasMany<Payment>()
                .WithOne()
                .IsRequired(true)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);
                */
            // Payment to User - M to 1 Relation
            modelBuilder.Entity<Payment>()
                .HasOne<AppUser>(p => p.User)
                .WithMany(u => u.Payments)
                .IsRequired(true)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict)
                .HasForeignKey(p => p.UserId);

            // Payment to Rental - 1 to Many Relation
            modelBuilder.Entity<Rental>()
                .HasOne<Payment>(r => r.Payment)
                .WithMany(p => p.Rentals)
                .IsRequired(true)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict)
                .HasForeignKey(r => r.RentalID);

            // Rental to Movie - 1 to 1 Relation
            modelBuilder.Entity<Rental>()
                .HasOne<Movie>(r => r.Movie)
                .WithMany()
                .IsRequired(true)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict)
                .HasForeignKey(r => r.MovieID);

            // User to UserMovies - 1 to 1 Relation
            modelBuilder.Entity<AppUserMovies>()
                .HasOne<AppUser>(u => u.User)
                .WithMany()
                .IsRequired(true)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict)
                .HasForeignKey(m => m.UserId);
        }
    }
}