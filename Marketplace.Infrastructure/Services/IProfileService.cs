using Marketplace.Infrastructure.Commands;
using Marketplace.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Infrastructure.Services
{
    public interface IProfileService
    {
        Task<IEnumerable<ProfileDTO>> BrowseAll();

        Task<ProfileDTO> GetProfile(int id);

        Task<ProfileDTO> GetProfileByUID(String id);

        Task<ProfileDTO> AddProfile(CreateProfile profile);

        Task<ProfileDTO> UpdateProfile(UpdateProfile profile, int id);

        Task DeleteProfile(int id);
    }
}
