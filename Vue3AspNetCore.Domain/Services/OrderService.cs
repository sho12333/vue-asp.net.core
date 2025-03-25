using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vue3AspNetCore.Domain.Entities.Orders;
using Vue3AspNetCore.Domain.Interface.Services;

namespace Vue3AspNetCore.Domain.Services
{
    public class OrderService : IOrderService
    {
        public Task<Order> CreateOrderAsync(int customerId, List<OrderItem> orderItems)
        {
            throw new NotImplementedException();
        }
    }
}