using ApiDomain.Storage;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace ApiDomain.Services
{
    public static class DataStorageServiceCollectionExtensions
    {
        public static IServiceCollection AddDataStorage(this IServiceCollection services) =>
            services.AddSingleton<IDataStorage, DataStorage>();
    }
}
