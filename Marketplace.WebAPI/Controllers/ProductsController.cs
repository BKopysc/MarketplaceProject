using Marketplace.Infrastructure.Commands;
using Marketplace.Infrastructure.DTO;
using Marketplace.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

           public ProductsController(IProductService productService)
            {
                _productService = productService;
            }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            IEnumerable<ProductDTO> z = await _productService.BrowseAll();
            return Json(z);
        }

        //https://localhost:5001/product/{id}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            Console.WriteLine($"get: {id}");
            ProductDTO z = await _productService.GetProduct(id);
            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProduct product)
        {
            Console.WriteLine($"Post: id - {product.ProductId}");
            ProductDTO z = await _productService.AddProduct(product);
            return Json(z);
        }

        [HttpPut("{id}")]
        public async Task UpdateProduct([FromBody] UpdateProduct product, int id)
        {
            Console.WriteLine($"Put: id {id}");
            await _productService.UpdateProduct(product, id);
            //return Json(z);
        }

        [HttpDelete("{id}")]
        public async Task DeleteProduct(int id)
        {
            Console.WriteLine($"Delete: id {id}");
            await _productService.DeleteProduct(id);
            //return Json(z);
        }
    }
}
