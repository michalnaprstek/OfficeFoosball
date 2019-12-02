using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;

namespace OfficeFoosball.DAL
{
    public static class DataStoreRegistrator
    {
        public static IServiceCollection RegisterSqlServer(IServiceCollection services, Action<DbContextOptionsBuilder> dbContextBuilder)
        {
            services.AddDbContext<FoosballContext>(dbContextBuilder, ServiceLifetime.Scoped);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDataStoreInitializer, DataStoreInitializer>();
            services.AddScoped<IDatabaseProvider, DatabaseProvider>();
            return services;
        }
    }
}
