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
    public class Offers_ProductsController : Controller
    {
        private readonly IOffer_ProductService _offer_ProductService;

        public Offers_ProductsController(IOffer_ProductService offer_ProductService)
        {
            _offer_ProductService = offer_ProductService;
        }

            [HttpGet]
            public async Task<IActionResult> BrowseAll()
            {
                IEnumerable<Offer_ProductDTO> z = await _offer_ProductService.BrowseAll();
                return Json(z);
            }

            //https://localhost:5001/offer_Product/{id}

            [HttpGet("{id}")]
            public async Task<IActionResult> GetOffer_Product(int id)
            {
                Console.WriteLine($"get: {id}");
                Offer_ProductDTO z = await _offer_ProductService.GetOffer_Product(id);
                return Json(z);
            }


            [HttpPost]
            public async Task<IActionResult> AddOffer_Product([FromBody] CreateOffer_Product offer_Product)
            {
                Console.WriteLine($"Post: id - {offer_Product.Id}");
                Offer_ProductDTO z = await _offer_ProductService.AddOffer_Product(offer_Product);
                return Json(z);
            }

            [HttpPut("{id}")]
            public async Task UpdateOffer_Product([FromBody] UpdateOffer_Product offer_Product, int id)
            {
                Console.WriteLine($"Put: id {id}");
                await _offer_ProductService.UpdateOffer_Product(offer_Product, id);
                //return Json(z);
            }

            [HttpDelete("{id}")]
            public async Task DeleteOffer_Product(int id)
            {
                Console.WriteLine($"Delete: id {id}");
                await _offer_ProductService.DeleteOffer_Product(id);
                //return Json(z);
            }
        }
}
