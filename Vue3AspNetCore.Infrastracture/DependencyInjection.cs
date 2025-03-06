using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vue3AspNetCore.Domain.Interface;
using Vue3AspNetCore.Infrastracture.Repositories;

namespace Vue3AspNetCore.Infrastracture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // リポジトリ
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}