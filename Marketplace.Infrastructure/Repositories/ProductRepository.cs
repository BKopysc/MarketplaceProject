using Marketplace.Core.Domain;
using Marketplace.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        public async Task<Product> AddSync(Product p)
        {
            try
            {
                _appDbContext.Product.Add(p);
                _appDbContext.SaveChanges();

                Console.WriteLine(p.ProductId);

                //Task.CompletedTask;
                return await Task.FromResult(_appDbContext.Product.FirstOrDefault(x => x.ProductId == p.ProductId));
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        
    }

        public async Task<IEnumerable<Product>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Product);
        }

        public async Task<IEnumerable<Product>> BrowseAllAsyncByPID(int PID)
        {
           return await Task.FromResult(_appDbContext.Product.Where(x => x.ProfileId == PID));
        }

        public async Task DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Product.FirstOrDefault(x => x.ProductId == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Product> GetAsync(int id)
        {
            try
            {
                return await Task.FromResult(_appDbContext.Product.FirstOrDefault(x => x.ProductId == id));

            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task<Product> UpdateAsync(Product p, int id)
        {
            try
            {
                var z = _appDbContext.Product.FirstOrDefault(x => x.ProductId == id);

                if (z == null)
                {
                    return null;
                }

                z.Description = p.Description;
                z.Name = p.Name;
                z.StatusType = p.StatusType;

                _appDbContext.SaveChanges();

                await Task.CompletedTask;
                return (z);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }
    }
}
