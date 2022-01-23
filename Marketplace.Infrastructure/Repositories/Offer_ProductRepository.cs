using Marketplace.Core.Domain;
using Marketplace.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Infrastructure.Repositories
{
    public class Offer_ProductRepository : IOffer_ProductRepository
    {
        private AppDbContext _appDbContext;

        public Offer_ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddMultipleAsync(List<Offer_Product> OpList)
        {
            try
            {
                foreach (Offer_Product op in OpList)
                {
                    _appDbContext.Offer_Products.Add(op);
                }
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Offer_Product> AddSync(Offer_Product o)
        {
            try
            {
                _appDbContext.Offer_Products.Add(o);
                _appDbContext.SaveChanges();

                Console.WriteLine(o.ProductId);

                //Task.CompletedTask;
                return await Task.FromResult(_appDbContext.Offer_Products.FirstOrDefault(x => x.ProductId == o.ProductId));
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task<IEnumerable<Offer_Product>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Offer_Products);
        }

        public async Task<IEnumerable<Offer_Product>> BrowseWithFilterAsync(int OfferId)
        {
            var o = _appDbContext.Offer_Products.Where(x => x.OfferId == OfferId).AsEnumerable();
            return await Task.FromResult(o);
        }

        public async Task DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Offer_Products.FirstOrDefault(x => x.ProductId == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Offer_Product> GetAsync(int id)
        {
            try
            {
                return await Task.FromResult(_appDbContext.Offer_Products.FirstOrDefault(x => x.ProductId == id));

            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task<Offer_Product> UpdateAsync(Offer_Product o, int id)
        {
            try
            {
                var z = _appDbContext.Offer_Products.FirstOrDefault(x => x.ProductId == id);

                if (z == null)
                {
                    return null;
                }

                z.OfferId = o.OfferId;
                z.ProductId = o.ProductId;

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
