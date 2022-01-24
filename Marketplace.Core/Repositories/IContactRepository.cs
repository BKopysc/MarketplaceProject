using Marketplace.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Repositories
{
    public interface IContactRepository
    {
        Task<Contact> UpdateAsync(Contact c, int id);
        Task<Contact> AddSync(Contact c);
        Task<Contact> GetByPIdAsync(int id);
        Task DelAsync(int id);
        Task<Contact> GetAsync(int id);
        Task<IEnumerable<Contact>> BrowseAllAsync();
    }
}
