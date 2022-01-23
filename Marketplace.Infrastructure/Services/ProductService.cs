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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;


        private ProductDTO MakeDTO(Product o)
        {
            ProductDTO prDTO = new ProductDTO()
            {
                ProductId = o.ProductId,
                Description = o.Description,
                Name = o.Name,
                StatusType = o.StatusType,

                //Offers = o.Offers,

            };
            return prDTO;
        }

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDTO> AddProduct(CreateProduct product)
        {
            Product pr = new Product()
            {
                ProductId = product.ProductId,
                Description = product.Description,
                Name = product.Name,
                StatusType = product.StatusType,
                ProfileId = product.ProfileId
                //Offers
            };
            var z = await _productRepository.AddSync(pr);

            if (z == null)
            {
                return null;
            }

            Console.WriteLine(z.ProductId);
            return MakeDTO(z);
        }

        public async Task<IEnumerable<ProductDTO>> BrowseAll()
        {
            var z = await _productRepository.BrowseAllAsync();
            return z.Select(x => MakeDTO(x));
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.DelAsync(id);
        }

        public async Task<ProductDTO> GetProduct(int id)
        {
            var z = await _productRepository.GetAsync(id);

            if (z == null)
            {
                return null;
            }
            return MakeDTO(z);
        }

        public async Task<ProductDTO> UpdateProduct(UpdateProduct product, int id)
        {
            Product pr = new Product()
            {
                Description = product.Description,
                Name = product.Name,
                StatusType = product.StatusType
                //Offers
            };

            var z = await _productRepository.UpdateAsync(pr, id);

            if (z == null)
            {
                return null;
            }
            return MakeDTO(z);
        }
    }
}
