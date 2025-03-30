using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vue3AspNetCore.Domain.Entities.Products;
using Vue3AspNetCore.Domain.Interface.Repositories;
using Vue3AspNetCore.Domain.Interface.Services;

namespace Vue3AspNetCore.Domain.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }

        public Task<Product> AddProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 全製品取得
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await inventoryRepository.GetProductsAsync();
        }

        public Task<IEnumerable<Product>> GetLowStockProductsAsync(int threshold)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> SearchProductsAsync(string term)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateStockQuantityAsync(int productId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}