﻿using ApiDomain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ApiDomain.Services
{
    public static class UserServiceCollectionExtensions
    {
        public static IServiceCollection AddUser(this IServiceCollection services) =>
            services.AddSingleton<IUserRepository, UserRepository>();
    }
}
