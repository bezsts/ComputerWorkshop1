using Microsoft.Extensions.DependencyInjection;

namespace ApiDomain.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUser(this IServiceCollection services) =>
            services.AddSingleton<UserStorage>();
    }
}
