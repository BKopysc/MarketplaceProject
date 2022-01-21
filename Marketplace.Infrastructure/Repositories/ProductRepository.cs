using Marketplace.Core.Domain;
using Marketplace.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Infrastructure.Repositories
{
    class ProductRepository : IProductRepository
    {
        public Task<Product> AddSync(Product p)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product p, int id)
        {
            throw new NotImplementedException();
        }
    }
}
