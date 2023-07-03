using Bogus;
using Bogus.DataSets;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUser(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var user = new ApplicationUser { Name = "John Doe", UserName = "admin", Email = "jdoe@jdoe.com" };

            if (userManager.Users.All(u => u.UserName != user.UserName))
            {
                await userManager.CreateAsync(user, "Admin1!");
                await userManager.AddToRolesAsync(user, new[] { administratorRole.Name });
            }
        }
    }
}
