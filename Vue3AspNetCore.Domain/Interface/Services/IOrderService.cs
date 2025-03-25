using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vue3AspNetCore.Domain.Entities.Orders;

namespace Vue3AspNetCore.Domain.Interface.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(int customerId, List<OrderItem> orderItems);
    }
}