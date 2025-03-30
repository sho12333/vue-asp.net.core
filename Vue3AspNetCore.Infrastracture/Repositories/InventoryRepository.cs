using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vue3AspNetCore.Domain.Entities.Products;
using Vue3AspNetCore.Domain.Interface.Repositories;
using Vue3AspNetCore.Infrastracture.Data;

namespace Vue3AspNetCore.Infrastracture.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly CustomDbContext _context;

        public InventoryRepository(CustomDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .OrderBy(p => p.Name)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}