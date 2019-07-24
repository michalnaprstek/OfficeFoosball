using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OfficeFoosball.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDal(this IServiceCollection services, IConfiguration configuration)
        {
            if (IsFakeActive(configuration))
                return Fakes.DataStoreRegistrator.RegisterFake(services);

            return DAL.DataStoreRegistrator.RegisterSqlServer(services, configuration["ConnectionString"]);
        }

        private static bool IsFakeActive(IConfiguration configuration)
            => configuration.GetValue<DataStoreType>("DataStoreType") == DataStoreType.Fake;
    }

    public enum DataStoreType
    {
        Fake,
        SqlServer
    }
}
