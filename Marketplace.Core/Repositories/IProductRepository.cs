using Marketplace.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Repositories
{
    public interface IProductRepository
    {
        Task UpdateAsync(Product p, int id);
        Task<Product> AddSync (Product p);
        Task DelAsync(int id);
        Task<Product> GetAsync(int id);
        Task<IEnumerable<Product>> BrowseAllAsync();
    }

}
