using Marketplace.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Repositories
{
    public interface IProfileRepository
    {
        Task<Profile> UpdateAsync(Profile p, int id);
        Task<Profile> AddSync(Profile p);
        Task DelAsync(int id);
        Task<Profile> GetAsync(int id);
        Task<IEnumerable<Profile>> BrowseAllAsync();
    }
}
