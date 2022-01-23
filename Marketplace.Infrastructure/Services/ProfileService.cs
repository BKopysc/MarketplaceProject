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
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;


        private ProfileDTO MakeDTO(Profile p)
        {
            ProfileDTO prDTO = new ProfileDTO()
            {
                ProfileId = p.ProfileId,
                Name = p.Name,
                Sex = p.Sex,
                Surname = p.Surname
                //Offers = p.Offers,
            };
            return prDTO;
        }


        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<IEnumerable<ProfileDTO>> BrowseAll()
        {
            var z = await _profileRepository.BrowseAllAsync();
            return z.Select(x => MakeDTO(x));
        }

        public async Task<ProfileDTO> GetProfile(int id)
        {
            var z = await _profileRepository.GetAsync(id);

            if (z == null)
            {
                return null;
            }
            return MakeDTO(z);
        }

        public async Task<ProfileDTO> AddProfile(CreateProfile profile)
        {
            Profile pr = new Profile()
            {
                ProfileId = profile.ProfileId,
                Name = profile.Name,
                Sex = profile.Sex,
                Surname = profile.Surname
                //Offers
            };
            var z = await _profileRepository.AddSync(pr);

            if (z == null)
            {
                return null;
            }

            Console.WriteLine(z.ProfileId);
            return MakeDTO(z);
        }

        public async Task<ProfileDTO> UpdateProfile(UpdateProfile profile, int id)
        {
            Profile pr = new Profile()
            {
                Name = profile.Name,
                Sex = profile.Sex,
                Surname = profile.Surname
                //Offers
            };

            var z = await _profileRepository.UpdateAsync(pr, id);

            if (z == null)
            {
                return null;
            }
            return MakeDTO(z);
        }

        public async Task DeleteProfile(int id)
        {
            await _profileRepository.DelAsync(id);
        }


    }
}
