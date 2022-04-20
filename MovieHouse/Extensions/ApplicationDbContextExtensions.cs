using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MovieHouse.Configurations;
using MovieHouse.Infrastructure.Data;
using MovieHouse.Infrastructure.Data.Identity;

namespace MovieHouse.Extensions
{
   public static class ApplicationDbContextExtensions
    {
        public static async Task EnsureSeeded(AdminUserSeedConfiguration adminUserSeedConfiguration, IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                await roleStore.CreateAsync(new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });

                var userStore = new UserStore<ApplicationUser>(context);
                var adminUser = new ApplicationUser
                {
                    Email = adminUserSeedConfiguration.Email,
                    FirstName = adminUserSeedConfiguration.FirstName,
                    LastName = adminUserSeedConfiguration.LastName,
                    Age = adminUserSeedConfiguration.Age,
                    CountryId = adminUserSeedConfiguration.CountryId,
                    CityId = adminUserSeedConfiguration.CityId,
                    UserName = adminUserSeedConfiguration.Email,
                    NormalizedUserName = adminUserSeedConfiguration.Email,
                    EmailConfirmed = true,
                    NormalizedEmail = adminUserSeedConfiguration.Email

                };

                var password = new PasswordHasher<ApplicationUser>();
                
                var hashed = password.HashPassword(adminUser, adminUserSeedConfiguration.Password);
                adminUser.PasswordHash = hashed;

                
                var result = userStore.CreateAsync(adminUser);

                UserManager<ApplicationUser> _userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
                ApplicationUser user = await _userManager.FindByEmailAsync(adminUser.Email);
                await userStore.AddToRoleAsync(user, "Admin");

               await context.SaveChangesAsync();
            }
            
        }
       

    }
}
