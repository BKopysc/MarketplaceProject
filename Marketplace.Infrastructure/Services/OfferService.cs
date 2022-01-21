using Marketplace.Core.Domain;
using Marketplace.Core.Repositories;
using Marketplace.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Infrastructure.Services
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;

        private OfferDTO MakeDTO(Offer o)
        {
            OfferDTO offDTO = new OfferDTO()
            {
                Name = o.Name,
                AuthorName = o.AuthorName,
                Active = o.Active,
                CreatedDate = o.CreatedDate,
                OfferId = o.OfferId,
                Price = o.Price,
                //Products = (ICollection<ProductDTO>)o.Products,
                //Comments = new List<CommentDTO>(o.Comments)
            };
            return offDTO;
        }

        public OfferService(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }
        public async Task<IEnumerable<OfferDTO>> BrowseAll()
        {
            var z = await _offerRepository.BrowseAllAsync();
            return z.Select(x => MakeDTO(x));
        }

        public Task<IEnumerable<OfferDTO>> BrowseWithFilter(string name, string country)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOffer(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OfferDTO> GetOffer(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OfferDTO> AddOffer(CreateSkiJumper skiJumper)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOffer(UpdateSkiJumper skiJumper, int id)
        {
            throw new NotImplementedException();
        }
    }
}
