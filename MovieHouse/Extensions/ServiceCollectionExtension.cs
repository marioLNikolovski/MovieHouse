using Microsoft.EntityFrameworkCore;
using MovieHouse.Configurations;
using MovieHouse.Core.Contracts;
using MovieHouse.Core.Services;
using MovieHouse.Infrastructure.Data;
using MovieHouse.Infrastructure.Data.Common;
using MovieHouse.Infrastructure.Data.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IApplicationDbRepository, ApplicationDbRepository>();
                
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IActorService, ActorService>();

            services.Configure<AdminUserSeedConfiguration>(configuration.GetSection(AdminUserSeedConfiguration.SECTION_NAME));


            return services;
        }

        public static IServiceCollection AddApplicationDbContexts(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
    }
}
