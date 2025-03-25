using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vue3AspNetCore.Domain.Entities.Customers;
using Vue3AspNetCore.Domain.Entities.Orders;
using Vue3AspNetCore.Domain.Entities.Products;

namespace Vue3AspNetCore.Tests.EntityTest
{
    public class OrderTest
    {
        [Fact]
        public void AddOrderItem_WithValidItem_ShouldAddItemToOrder()
        {
            // Arrange
            var orderItem = new OrderItem
            {
                ProductId = 1,
                Quantity = 2,
                UnitPrice = 10
            };

            // Act
            var order = new Order();
            order.AddOrderItem(orderItem);

            // Assert
            Assert.Single(order.OrderItems);
            Assert.Equal(orderItem.ProductId, order.OrderItems.First().ProductId);
            Assert.Equal(orderItem.Quantity, order.OrderItems.First().Quantity);
            Assert.Equal(orderItem.UnitPrice, order.OrderItems.First().UnitPrice);
        }
    }
}