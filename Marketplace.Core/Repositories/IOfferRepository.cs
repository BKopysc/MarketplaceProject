using Marketplace.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Repositories
{
    public interface IOfferRepository
    {
        Task<Offer> UpdateAsync(Offer o, int id);
        Task<Offer> AddSync(Offer o);
        Task DelAsync(int id);
        Task<Offer> GetAsync(int id);
        Task<IEnumerable<Offer>> BrowseAllAsync();

        Task<IEnumerable<Offer>> BrowseWithFilterAsync(string name, bool active);
    }
}
