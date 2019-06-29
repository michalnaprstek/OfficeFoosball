using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OfficeFoosball.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDal(this IServiceCollection services, IConfiguration configuration)
        {
            var dataStoreType = configuration.GetValue<DataStoreType>("DataStoreType");

            switch (dataStoreType)
            {
                case DataStoreType.SqlServer:
                    return DAL.DataStoreRegistrator.RegisterSqlServer(services, configuration["ConnectionString"]);

                case DataStoreType.Fake:
                     return Fakes.DataStoreRegistrator.RegisterFake(services);
            }
            return services;
        }
    }

    public enum DataStoreType
    {
        Fake,
        SqlServer
    }
}
