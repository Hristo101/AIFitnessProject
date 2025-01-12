using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Services;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AIFitnessServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITrainerService, TrainerService>();
          

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddScoped<IRepository, Repository>();

            return services;
        }


        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {

            services
                .AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;

        }
    }
}
