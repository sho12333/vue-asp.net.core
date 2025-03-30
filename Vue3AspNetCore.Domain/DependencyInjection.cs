using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vue3AspNetCore.Domain.Interface.Repositories;
using Vue3AspNetCore.Domain.Interface.Services;
using Vue3AspNetCore.Domain.Services;

namespace Vue3AspNetCore.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainService(this IServiceCollection services)
        {
            // サービス
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}