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
    public class Offer_ProductService : IOffer_ProductService
    {
        private readonly IOffer_ProductRepository _offer_ProductRepository;

        private Offer_ProductDTO MakeDTO(Offer_Product o)
        {
            Offer_ProductDTO cDTO = new Offer_ProductDTO()
            {
                Id = o.Id,
                OfferId = o.OfferId,
                ProductId = o.ProductId
                //Offers = o.Offers,

            };
            return cDTO;
        }
        public Offer_ProductService(IOffer_ProductRepository offer_ProductRepository)
        {
            _offer_ProductRepository = offer_ProductRepository;
        }

        public async Task AddMultipleOffer_Product(List<CreateOffer_Product> Offer_ProductList)
        {
            List<Offer_Product> offList = new List<Offer_Product>();

            foreach (CreateOffer_Product cop in Offer_ProductList)
            {
                Offer_Product c = new Offer_Product()
                {
                    Id = cop.Id,
                    OfferId = cop.OfferId,
                    ProductId = cop.ProductId
                    //Offers
                };

                offList.Add(c);
            }

            await _offer_ProductRepository.AddMultipleAsync(offList);

        }

        public async Task<Offer_ProductDTO> AddOffer_Product(CreateOffer_Product Offer_Product)
        {
            Offer_Product c = new Offer_Product()
            {
                Id = Offer_Product.Id,
                OfferId = Offer_Product.OfferId,
                ProductId = Offer_Product.ProductId
                //Offers
            };
            var z = await _offer_ProductRepository.AddSync(c);

            if (z == null)
            {
                return null;
            }

            Console.WriteLine(z.Id);
            return MakeDTO(z);
        }

        public async Task<IEnumerable<Offer_ProductDTO>> BrowseAll()
        {
            var z = await _offer_ProductRepository.BrowseAllAsync();
            return z.Select(x => MakeDTO(x));
        }

        public async Task<IEnumerable<Offer_ProductDTO>> BrowseWithFilter(int OfferId)
        {
            var z = await _offer_ProductRepository.BrowseWithFilterAsync(OfferId);

            if (z == null)
            {
                return null;
            }
            return z.Select(X => MakeDTO(X));

        }

        public async Task DeleteOffer_Product(int id)
        {
            await _offer_ProductRepository.DelAsync(id);
        }

        public async Task<Offer_ProductDTO> GetOffer_Product(int id)
        {
            var z = await _offer_ProductRepository.GetAsync(id);

            if (z == null)
            {
                return null;
            }
            return MakeDTO(z);
        }

        public async Task<Offer_ProductDTO> UpdateOffer_Product(UpdateOffer_Product Offer_Product, int id)
        {
            Offer_Product c = new Offer_Product()
            {
                OfferId = Offer_Product.OfferId,
                ProductId = Offer_Product.ProductId
            };

            var z = await _offer_ProductRepository.UpdateAsync(c, id);

            if (z == null)
            {
                return null;
            }
            return MakeDTO(z);
        }
    }
}
