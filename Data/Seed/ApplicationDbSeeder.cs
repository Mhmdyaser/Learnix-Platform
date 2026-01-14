using Learnix.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Learnix.Data.Seed
{
    public static class ApplicationDbSeeder
    {
        public static async Task SeedAsync(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            LearnixContext context)
        {
            await SeedRoles(roleManager);
            await SeedAdminUser(userManager, roleManager, context);
        }

        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { "Admin", "Instructor", "Student" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        private static async Task SeedAdminUser(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            LearnixContext context)
        {
            string adminEmail = "admin@site.com";
            string adminPassword = "Admin@123";

            var existingAdmin = await userManager.FindByEmailAsync(adminEmail);

            if (existingAdmin == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin444",
                    Email = adminEmail,
                    FirstName = "System",
                    LastName = "Admin",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");

                    // Add Admin record
                    if (!context.Admins.Any(a => a.Id == adminUser.Id))
                    {
                        context.Admins.Add(new Admin
                        {
                            Id = adminUser.Id,
                            Balance = 0
                        });

                        await context.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
