using Marketplace.Infrastructure.Commands;
using Marketplace.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Infrastructure.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> BrowseAll();

        Task<IEnumerable<ProductDTO>> BrowseAllByPID(int PID);

        Task<ProductDTO> GetProduct(int id);

        Task<ProductDTO> AddProduct(CreateProduct product);

        Task<ProductDTO> UpdateProduct(UpdateProduct product, int id);

        Task DeleteProduct(int id);
    }
}
