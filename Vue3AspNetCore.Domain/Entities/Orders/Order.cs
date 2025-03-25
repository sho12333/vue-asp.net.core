using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vue3AspNetCore.Domain.Entities.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string Status { get; set; } = "新規";
        public ICollection<OrderItem> OrderItems { get; set; }
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 受注項目追加
        /// </summary>
        /// <param name="orderItem"></param>
        public void AddOrderItem(OrderItem orderItem)
        {
            if (OrderItems == null)
            {
                OrderItems = new List<OrderItem>();
            }

            OrderItems.Add(orderItem);
        }
    }
}