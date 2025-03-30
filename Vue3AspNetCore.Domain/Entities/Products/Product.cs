using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Vue3AspNetCore.Domain.Entities.Users;

namespace Vue3AspNetCore.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int? CategoryId { get; set; }

        [JsonIgnore]
        public Category Category { get; set; } = new Category();
    }
}