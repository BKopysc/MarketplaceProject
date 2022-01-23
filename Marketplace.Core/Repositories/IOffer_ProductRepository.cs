using Marketplace.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Repositories
{
    public interface IOffer_ProductRepository
    {
        Task<Offer_Product> UpdateAsync(Offer_Product o, int id);
        Task<Offer_Product> AddSync(Offer_Product o);
        Task AddMultipleAsync(List<Offer_Product> OpList);
        Task DelAsync(int id);
        Task<Offer_Product> GetAsync(int id);
        Task<IEnumerable<Offer_Product>> BrowseAllAsync();
        Task<IEnumerable<Offer_Product>> BrowseWithFilterAsync(int OfferId);
    }
}
