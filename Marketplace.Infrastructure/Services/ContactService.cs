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
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        private ContactDTO MakeDTO(Contact o)
        {
            ContactDTO cDTO = new ContactDTO()
            {
                City = o.City,
                ContactId = o.ContactId,
                Country = o.Country,
                County = o.County,
                Phone = o.Phone,
                ProfileId = o.ProfileId
                //Offers = o.Offers,

            };
            return cDTO;
        }

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<ContactDTO> AddContact(CreateContact contact)
        {
            Contact c = new Contact()
            {
                City = contact.City,
                ContactId = contact.ContactId,
                Country = contact.Country,
                County = contact.County,
                Phone = contact.Phone,
                ProfileId = contact.ProfileId
                //Offers
            };
            var z = await _contactRepository.AddSync(c);

            if (z == null)
            {
                return null;
            }

            Console.WriteLine(z.ContactId);
            return MakeDTO(z);
        }

        public async Task<IEnumerable<ContactDTO>> BrowseAll()
        {
            var z = await _contactRepository.BrowseAllAsync();
            return z.Select(x => MakeDTO(x));
        }

        public async Task DeleteContact(int id)
        {
            await _contactRepository.DelAsync(id);
        }

        public async Task<ContactDTO> GetContact(int id)
        {
            var z = await _contactRepository.GetAsync(id);

            if (z == null)
            {
                return null;
            }
            return MakeDTO(z);
        }

        public async Task<ContactDTO> UpdateContact(UpdateContact contact, int id)
        {
            Contact c = new Contact()
            {
                City = contact.City,
                Country = contact.Country,
                County = contact.County,
                Phone = contact.Phone,
                ProfileId = contact.ProfileId
            };

            var z = await _contactRepository.UpdateAsync(c, id);

            if (z == null)
            {
                return null;
            }
            return MakeDTO(z);
        }

        public async Task<ContactDTO> GetContactByPId(int id)
        {
            var z = await _contactRepository.GetByPIdAsync(id);

            if (z == null)
            {
                return null;
            }
            return MakeDTO(z);
        }
    }
}
