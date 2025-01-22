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
                && await roleManager.RoleExistsAsync(DietitianRole) == false)
                
            {
                var role = new IdentityRole(TrainerRole);
                role.ConcurrencyStamp = Guid.NewGuid().ToString();
                var role2 = new IdentityRole(DietitianRole);
                role2.ConcurrencyStamp = Guid.NewGuid().ToString();
            

                await roleManager.CreateAsync(role);
                await roleManager.CreateAsync(role2);
            

                var trainer = await userManager.FindByEmailAsync("svetoslav@abv.bg");
                var trainer2 = await userManager.FindByEmailAsync("daniela@abv.bg");
                var dietitian = await userManager.FindByEmailAsync("rosalina@abv.bg");
                var dietitian2 = await userManager.FindByEmailAsync("zhenya@abv.bg");

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
            }
        }
    }
}
