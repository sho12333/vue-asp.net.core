using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Vue3AspNetCore.Infrastracture.Data;
using Vue3AspNetCore.Infrastracture.Repositories;
using Vue3AspNetCore.Domain.Interface.Repositories;

namespace Vue3AspNetCore.Infrastracture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // リポジトリ
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddDbContext<CustomDbContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}