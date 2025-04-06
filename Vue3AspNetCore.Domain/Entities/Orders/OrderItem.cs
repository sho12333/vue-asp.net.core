using Vue3AspNetCore.Domain.Entities.Products;

namespace Vue3AspNetCore.Domain.Entities.Orders
{
    /// <summary>
    /// 受注項目
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 受注ID
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 受注情報
        /// </summary>
        public Order Order { get; set; } = new();

        /// <summary>
        /// 製品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 製品情報
        /// </summary>
        public Product Product { get; set; } = new();

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 単価
        /// </summary>
        public decimal UnitPrice { get; set; }

        public void Validate()
        {
            if (Quantity <= 0)
            {
                throw new ArgumentException("数量は1以上でなければなりません。");
            }

            if (UnitPrice <= 0)
            {
                throw new ArgumentException("単価は0より大きい値でなければなりません。");
            }

            if (Product == null)
            {
                throw new ArgumentNullException(nameof(Product), "製品情報が登録されていません。");
            }
        }
    }
}