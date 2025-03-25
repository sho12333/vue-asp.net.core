using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vue3AspNetCore.Domain.Entities.Inventories
{
    public class Inventory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int TotalQuantity { get; set; }
        public int AvailableQuantity { get; set; }
        public int ReservedQuantity { get; set; }
    }
}