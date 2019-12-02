using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace OfficeFoosball.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDal(this IServiceCollection services, IConfiguration configuration)
        {
            switch (GetDataStoreType(configuration))
            {
                case DataStoreType.Fake:
                    return Fakes.DataStoreRegistrator.RegisterFake(services);
                case DataStoreType.SqlServer:
                    return DAL.DataStoreRegistrator.RegisterSqlServer(services, builder => builder.UseSqlServer(configuration["ConnectionString"]));
                case DataStoreType.PostgreSql:
                    return DAL.DataStoreRegistrator.RegisterSqlServer(services, builder => builder.UseNpgsql(configuration["ConnectionString"]));
                default:
                    throw new ArgumentOutOfRangeException("DataStoreType", "Unexpected DataStoreType obtained from configuration.");
            }
        }

        private static DataStoreType GetDataStoreType(IConfiguration configuration)
            => configuration.GetValue<DataStoreType>("DataStoreType");
    }

    public enum DataStoreType
    {
        Fake,
        SqlServer,
        PostgreSql
    }
}
