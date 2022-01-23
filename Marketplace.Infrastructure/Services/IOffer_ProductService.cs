using Marketplace.Infrastructure.Commands;
using Marketplace.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Infrastructure.Services
{
    public interface IOffer_ProductService
    {
        Task<IEnumerable<Offer_ProductDTO>> BrowseAll();

        Task<Offer_ProductDTO> GetOffer_Product(int id);

        Task<Offer_ProductDTO> AddOffer_Product(CreateOffer_Product Offer_Product);

        Task AddMultipleOffer_Product(List<CreateOffer_Product> Offer_ProductList);

        Task<Offer_ProductDTO> UpdateOffer_Product(UpdateOffer_Product Offer_Product, int id);

        Task DeleteOffer_Product(int id);

        Task<IEnumerable<Offer_ProductDTO>> BrowseWithFilter(int OfferId);
    }
}
