using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TemplateSolution.Infra.Data.Context;

namespace TemplateSolution.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<ContextDB>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
        }
    }
}
