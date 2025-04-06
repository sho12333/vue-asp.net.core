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

        [Fact]
        public void DeleteOrderItem_WithValidItem_ShouldRemoveItemFromOrder()
        {
            // Arrange
            var orderItem = new OrderItem
            {
                ProductId = 1,
                Quantity = 2,
                UnitPrice = 10
            };

            var order = new Order();
            order.AddOrderItem(orderItem);

            // Act
            order.DeleteOrderItem(orderItem);

            // Assert
            Assert.Empty(order.OrderItems);
        }

        [Fact]
        public void CalculateTotalPrice_ShouldReturnCorrectTotalPrice()
        {
            // Arrange
            var order = new Order();
            order.AddOrderItem(new OrderItem { ProductId = 1, Quantity = 2, UnitPrice = 10 });
            order.AddOrderItem(new OrderItem { ProductId = 2, Quantity = 1, UnitPrice = 20 });

            // Act
            var totalPrice = order.CalculateTotalPrice();

            // Assert
            Assert.Equal(40, totalPrice);
        }

        [Fact]
        public void ValidateOrderItem_ShouldThrowException_WhenQuantityIsZeroOrNegative()
        {
            // Arrange
            var orderItem = new OrderItem
            {
                ProductId = 1,
                Quantity = 0,
                UnitPrice = 10
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => orderItem.Validate());
        }

        [Fact]
        public void ValidateOrderItem_ShouldThrowException_WhenUnitPriceIsZeroOrNegative()
        {
            // Arrange
            var orderItem = new OrderItem
            {
                ProductId = 1,
                Quantity = 2,
                UnitPrice = -10
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => orderItem.Validate());
        }

        [Fact]
        public void ValidateOrderItem_ShouldThrowException_WhenProductIsNull()
        {
            // Arrange
            var orderItem = new OrderItem
            {
                ProductId = 1,
                Quantity = 2,
                UnitPrice = 10,
                Product = null
            };

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => orderItem.Validate());
        }

        [Fact]
        public void ValidateOrderItem_ShouldNotThrowException_WhenAllPropertiesAreValid()
        {
            // Arrange
            var orderItem = new OrderItem
            {
                ProductId = 1,
                Quantity = 2,
                UnitPrice = 10,
                Product = new Product { Id = 1, Name = "Test Product" }
            };

            // Act & Assert
            orderItem.Validate(); // Should not throw
        }

        [Fact]
        public void ValidateOrder_ShouldThrowException_WhenCustomerIsNull()
        {
            // Arrange
            var order = new Order
            {
                Customer = new(),
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { ProductId = 1, Quantity = 2, UnitPrice = 10 }
                }
            };

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => order.Validate());
        }

        [Fact]
        public void ValidateOrder_ShouldThrowException_WhenOrderItemsIsNullOrEmpty()
        {
            // Arrange
            var order = new Order
            {
                Customer = new(),
                OrderItems = []
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => order.Validate());
        }
    }
}