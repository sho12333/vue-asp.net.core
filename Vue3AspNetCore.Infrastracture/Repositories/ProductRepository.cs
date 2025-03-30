using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vue3AspNetCore.Domain.Entities.Products;
using Vue3AspNetCore.Domain.Interface.Repositories;

namespace Vue3AspNetCore.Infrastracture.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> SearchAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}