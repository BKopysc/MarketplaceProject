using Marketplace.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Infrastructure.Services
{
    public interface IOfferService
    {
        Task<IEnumerable<OfferDTO>> BrowseAll();

        Task<OfferDTO> GetOffer(int id);

        Task<OfferDTO> AddOffer(CreateOffer offer);

        Task UpdateOffer(UpdateOffer offer, int id);

        Task DeleteOffer(int id);

        Task<IEnumerable<OfferDTO>> BrowseWithFilter(string name, string country);
    }
}
