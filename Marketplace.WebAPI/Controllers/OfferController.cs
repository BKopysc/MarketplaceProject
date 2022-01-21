﻿using Marketplace.Infrastructure.Commands;
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
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;
        
        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            IEnumerable<OfferDTO> z = await _offerService.BrowseAll();
            return Json(z);
        }

        //https://localhost:5001/offer/{id}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOffer(int id)
        {
            Console.WriteLine($"get: {id}");
            OfferDTO z = await _offerService.GetOffer(id);
            return Json(z);
        }

        ////https://localhost:5001/skijumper/filter?name=alan&country=ger
        //[HttpGet("filter")]
        //public async Task<IActionResult> GetByFilter(string name, string country)
        //{
        //    Console.WriteLine($"Get Filter: name: {name}, country: {country}");
        //    IEnumerable<SkiJumperDTO> z = await _skiJumperService.BrowseWithFilter(name, country);
        //    return Json(z);
        //}

        [HttpPost]
        public async Task<IActionResult> AddOffer([FromBody] CreateOffer offer)
        {
            Console.WriteLine($"Post: id - {offer.OfferId}");
            OfferDTO z = await _offerService.AddOffer(offer);
            return Json(z);
        }

        [HttpPut("{id}")]
        public async Task UpdateOffer([FromBody] UpdateOffer offer, int id)
        {
            Console.WriteLine($"Put: id {id}");
            await _offerService.UpdateOffer(offer, id);
            //return Json(z);
        }

        [HttpDelete("{id}")]
        public async Task DeleteOffer(int id)
        {
            Console.WriteLine($"Delete: id {id}");
            await _offerService.DeleteOffer(id);
            //return Json(z);
        }
    }
}
