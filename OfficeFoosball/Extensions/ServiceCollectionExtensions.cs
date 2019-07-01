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

        public static IServiceCollection SetupAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            if(IsFakeActive(configuration))
                return Fakes.AuthInitializer.Init(services);

            return DAL.AuthInitializer.Init(services, configuration);
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
