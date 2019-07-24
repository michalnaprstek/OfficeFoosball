using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OfficeFoosball.DAL.Entities;

namespace OfficeFoosball.DAL
{
    public static class AuthInitializer
    {
        public static IServiceCollection Init(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 8;
                })
                .AddEntityFrameworkStores<FoosballContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
