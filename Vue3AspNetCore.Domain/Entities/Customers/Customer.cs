using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vue3AspNetCore.Domain.Entities.Users;

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
        /// TODO 顧客のクレジット限度額
        /// </summary>
        public int CreditLimit { get; set; }
    }
}