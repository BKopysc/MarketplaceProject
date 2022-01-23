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
    public class ProfilesController : Controller
    {
        private readonly IProfileService _profileService;

        public ProfilesController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            IEnumerable<ProfileDTO> z = await _profileService.BrowseAll();
            return Json(z);
        }

        //https://localhost:5001/profile/{id}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile(int id)
        {
            Console.WriteLine($"get: {id}");
            ProfileDTO z = await _profileService.GetProfile(id);
            return Json(z);
        }


        [HttpPost]
        public async Task<IActionResult> AddProfile([FromBody] CreateProfile profile)
        {
            Console.WriteLine($"Post: id - {profile.ProfileId}");
            ProfileDTO z = await _profileService.AddProfile(profile);
            return Json(z);
        }

        [HttpPut("{id}")]
        public async Task UpdateProfile([FromBody] UpdateProfile profile, int id)
        {
            Console.WriteLine($"Put: id {id}");
            await _profileService.UpdateProfile(profile, id);
            //return Json(z);
        }

        [HttpDelete("{id}")]
        public async Task DeleteProfile(int id)
        {
            Console.WriteLine($"Delete: id {id}");
            await _profileService.DeleteProfile(id);
            //return Json(z);
        }
    }
}
