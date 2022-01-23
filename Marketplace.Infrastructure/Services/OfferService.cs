using Marketplace.Core.Domain;
using Marketplace.Core.Repositories;
using Marketplace.Infrastructure.Commands;
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

        public async Task<IEnumerable<OfferDTO>> BrowseWithFilter(string name, bool active)
        {
            var z = await _offerRepository.BrowseWithFilterAsync(name, active);

            if (z == null)
            {
                return null;
            }
            return z.Select(X => MakeDTO(X));

        
        }

        public async Task DeleteOffer(int id)
        {
            await _offerRepository.DelAsync(id);
        }

        public  async Task<OfferDTO> GetOffer(int id)
        {
            var z = await _offerRepository.GetAsync(id);

            if (z == null)
            {
                return null;
            }
            return MakeDTO(z);
        }

        public async Task<OfferDTO> AddOffer(CreateOffer offer)
        {
            Offer of = new Offer()
            {
                OfferId = offer.OfferId,
                Name = offer.Name,
                Price = offer.Price,
                Active = offer.Active,
                CreatedDate = offer.CreatedDate,
            };

            var z = await _offerRepository.AddSync(of);

            if (z == null)
            {
                return null;
            }

            Console.WriteLine(z.OfferId);
            return MakeDTO(z);
        }

        public async Task<OfferDTO> UpdateOffer(UpdateOffer offer, int id)
        {
            Offer of = new Offer()
            {
                //OfferId = offer.OfferId,
                Name = offer.Name,
                Price = offer.Price,
                Active = offer.Active,
                CreatedDate = offer.CreatedDate,
            };

            var z = await _offerRepository.UpdateAsync(of, id);

            if(z == null)
            {
                return null;
            }
            return MakeDTO(z);
        }
    }
}
