namespace Vue3AspNetCore.Domain.Entities.Customers
{
    /// <summary>
    /// 顧客
    /// </summary>
    public class Customer : BaseEntity
    {
        /// <summary>
        /// 顧客ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 顧客名
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// TODO Type
        /// </summary>
        public string CustomerType { get; set; } = string.Empty;

        /// <summary>
        /// 住所
        /// </summary>
        public string CustomerAddress { get; set; } = string.Empty;

        /// <summary>
        /// 市
        /// </summary>
        public string CustomerCity { get; set; } = string.Empty;

        /// <summary>
        /// 州
        /// </summary>
        public string CustomerState { get; set; } = string.Empty;

        /// <summary>
        /// 郵便コード
        /// </summary>
        public string CustomerZip { get; set; } = string.Empty;

        /// <summary>
        /// 国
        /// </summary>
        public string CustomerCountry { get; set; } = string.Empty;

        /// <summary>
        /// 携帯番号
        /// </summary>
        public string CustomerPhone { get; set; } = string.Empty;

        /// <summary>
        /// メールアドレス
        /// </summary>
        public string CustomerEmail { get; set; } = string.Empty;

        /// <summary>
        /// TODO 顧客のクレジット限度額
        /// </summary>
        public int CreditLimit { get; set; }
    }
}