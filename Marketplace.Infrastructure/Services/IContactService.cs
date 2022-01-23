using Marketplace.Infrastructure.Commands;
using Marketplace.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Infrastructure.Services
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDTO>> BrowseAll();

        Task<ContactDTO> GetContact(int id);

        Task<ContactDTO> AddContact(CreateContact contact);

        Task<ContactDTO> UpdateContact(UpdateContact contact, int id);

        Task DeleteContact(int id);
    }
}
