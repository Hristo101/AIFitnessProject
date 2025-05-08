using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using static AIFitnessProject.Core.Constants.RoleConstants;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtension
    {
        public static async Task CreateRolesAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (roleManager != null && userManager != null
                && await roleManager.RoleExistsAsync(TrainerRole) == false
                && await roleManager.RoleExistsAsync(DietitianRole) == false
                && await roleManager.RoleExistsAsync(AdminRole) == false)
                
            {
                var role = new IdentityRole(TrainerRole);
                role.ConcurrencyStamp = Guid.NewGuid().ToString();
                var role2 = new IdentityRole(DietitianRole);
                role2.ConcurrencyStamp = Guid.NewGuid().ToString();
                var role3 = new IdentityRole(AdminRole);
                role3.ConcurrencyStamp = Guid.NewGuid().ToString();

                await roleManager.CreateAsync(role);
                await roleManager.CreateAsync(role2);
                await roleManager.CreateAsync(role3);

                var trainer = await userManager.FindByEmailAsync("pierceabv980@gmail.com");
                var trainer2 = await userManager.FindByEmailAsync("pmgclaude.team06@gmail.com");
                var dietitian = await userManager.FindByEmailAsync("jd6125416@gmail.com");
                var dietitian2 = await userManager.FindByEmailAsync("m.smith.online@gmail.com");
                var admin = await userManager.FindByEmailAsync("hserev789@gmail.com");
                if (trainer != null)
                {
                    await userManager.AddToRoleAsync(trainer, role.Name);
                }

                if (trainer2 != null)
                {
                    await userManager.AddToRoleAsync(trainer2, role.Name);
                }

                if (dietitian != null)
                {
                    await userManager.AddToRoleAsync(dietitian, role2.Name);
                }

                if (dietitian2 != null)
                {
                    await userManager.AddToRoleAsync(dietitian2, role2.Name);
                }

                if (admin != null)
                {
                    await userManager.AddToRoleAsync(admin, role3.Name);
                }
            }
        }
    }
}
