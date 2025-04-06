using Vue3AspNetCore.Domain.Entities.Customers;

namespace Vue3AspNetCore.Domain.Entities.Orders
{
    /// <summary>
    /// 受注
    /// </summary>
    public class Order
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 顧客
        /// </summary>
        public Customer Customer { get; set; } = new();

        public string Status { get; set; } = "新規";

        /// <summary>
        /// 受注項目
        /// </summary>
        public ICollection<OrderItem> OrderItems { get; set; } = [];

        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 受注項目追加
        /// </summary>
        /// <param name="orderItem"></param>
        public void AddOrderItem(OrderItem orderItem)
        {
            OrderItems ??= new List<OrderItem>();

            OrderItems.Add(orderItem);
        }

        /// <summary>
        /// 受注項目削除
        /// </summary>
        /// <param name="orderItem"></param>
        public void DeleteOrderItem(OrderItem orderItem)
        {
            OrderItems?.Remove(orderItem);
        }

        /// <summary>
        /// 全体金額計算
        /// </summary>
        /// <returns></returns>
        public decimal CalculateTotalPrice()
        {
            return OrderItems?.Sum(item => item.Quantity * item.UnitPrice) ?? 0;
        }

        /// <summary>
        /// 検証
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public void Validate()
        {
            if (OrderItems == null || OrderItems.Count == 0)
            {
                throw new ArgumentException("受注項目が登録されていません。");
            }

            foreach (var item in OrderItems)
            {
                item.Validate();
            }

            if (Customer == null || string.IsNullOrEmpty(Customer.Name))
            {
                throw new ArgumentNullException(nameof(Customer), "顧客情報が登録されていません。");
            }
        }
    }
}