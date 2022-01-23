using Marketplace.Infrastructure.Commands;
using Marketplace.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Infrastructure.Services
{
    public class ContactService : IContactService
    {
        public Task<ContactDTO> AddContact(CreateContact contact)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContactDTO>> BrowseAll()
        {
            throw new NotImplementedException();
        }

        public Task DeleteContact(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ContactDTO> GetContact(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ContactDTO> UpdateContact(UpdateContact contact, int id)
        {
            throw new NotImplementedException();
        }
    }
}
