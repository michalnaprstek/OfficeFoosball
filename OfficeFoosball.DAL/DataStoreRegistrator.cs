using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace OfficeFoosball.DAL
{
    public static class DataStoreRegistrator
    {
        public static IServiceCollection RegisterSqlServer(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<FoosballContext>(
                builder => builder.UseSqlServer(connectionString, o =>
                {
                }), ServiceLifetime.Scoped);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDataStoreInitializer, DataStoreInitializer>();
            return services;
        }
    }
}
