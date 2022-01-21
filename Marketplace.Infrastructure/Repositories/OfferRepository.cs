using Marketplace.Core.Domain;
using Marketplace.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Infrastructure.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        public static List<Offer> _offerMock = new List<Offer>();
        public OfferRepository()
        {
            _offerMock.Add(new Offer()
            {
                OfferId = 1,
                AuthorName = "Adam",
                Active = true,
                Comments = null,
                CreatedDate = new DateTime(),
                Name = "Sofa",
                Price = 100,
                Products = null
            }) ;
        }
        public Task<Offer> AddSync(Offer o)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Offer>> BrowseAllAsync()
        {
            return await Task.FromResult(_offerMock);
        }

        public Task<IEnumerable<Offer>> BrowseWithFilterAsync(string name, bool active)
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Offer> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Offer o, int id)
        {
            throw new NotImplementedException();
        }
    }
}
