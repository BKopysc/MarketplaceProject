using Marketplace.Infrastructure.Commands;
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

        Task<IEnumerable<OfferDTO>> BrowseAllByPID(int PID);

        Task<OfferDTO> AddOffer(CreateOffer offer);

        Task<OfferDTO> UpdateOffer(UpdateOffer offer, int id);

        Task DeleteOffer(int id);

        Task<IEnumerable<OfferDTO>> BrowseWithFilter(string name, bool active);
    }
}
