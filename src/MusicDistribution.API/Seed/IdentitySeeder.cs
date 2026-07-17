using Microsoft.AspNetCore.Identity;
using MusicDistribution.Domain.Identity;

namespace MusicDistribution.API.Seed
{
    public static class IdentitySeeder
    {
        public static async Task SeedAdminUserAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            const string username = "admin";
            const string email = "admin@musicdistribution.com";
            const string password = "Admin@123";

            var existingUser = await userManager.FindByNameAsync(username);

            if (existingUser != null)
                return;

            var user = new ApplicationUser
            {
                UserName = username,
                Email = email,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Failed to create admin user: {errors}");
            }
        }
    }
}
