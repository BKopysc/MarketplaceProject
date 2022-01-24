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
    public class ContactsController : Controller
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            IEnumerable<ContactDTO> z = await _contactService.BrowseAll();
            return Json(z);
        }

        //https://localhost:5001/contact/{id}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            Console.WriteLine($"get: {id}");
            ContactDTO z = await _contactService.GetContact(id);
            return Json(z);
        }
        [HttpGet("pid")]
        public async Task<IActionResult> GetByFilter(int id)
        {
            ContactDTO z = await _contactService.GetContactByPId(id);
            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] CreateContact contact)
        {
            Console.WriteLine($"Post: id - {contact.ContactId}");
            ContactDTO z = await _contactService.AddContact(contact);
            return Json(z);
        }

        [HttpPut("{id}")]
        public async Task UpdateContact([FromBody] UpdateContact contact, int id)
        {
            Console.WriteLine($"Put: id {id}");
            await _contactService.UpdateContact(contact, id);
            //return Json(z);
        }

        [HttpDelete("{id}")]
        public async Task DeleteContact(int id)
        {
            Console.WriteLine($"Delete: id {id}");
            await _contactService.DeleteContact(id);
            //return Json(z);
        }
    }
}
