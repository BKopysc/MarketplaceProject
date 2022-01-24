using Marketplace.Core.Domain;
using Marketplace.WebApp.Commands;
using Marketplace.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.WebApp.Controllers
{
    public class ProfilesController : Controller
    {
        public IConfiguration Configuration;
        private UserManager<ApplicationUser> _userManager;


        public ProfilesController(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            Configuration = configuration;
            _userManager = userManager;
        }

        public ContentResult GetHostUrl()
        {
            var result = Configuration["RestApiUrl:HostUrl"];
            return Content(result);
        }
        private string CN()
        {
            string cn = ControllerContext.RouteData.Values["controller"].ToString();
            return cn;
        }

        public async Task<IActionResult> IndexAsync()
        {
            string _restpath = GetHostUrl().Content + CN();
            string _plainrest = GetHostUrl().Content;

            ClaimsPrincipal currentUser = this.User;
            var currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _userManager.GetUserAsync(currentUser).Result;
            //var currentUserEmail = currentUser.FindFirst(ClaimTypes.Email).Value;


            ProfileVM model = new ProfileVM();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync($"{_restpath}/uid?id={currentUserId}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject < ProfileVM > (apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }

            ContactVM contactModel = new ContactVM();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync($"{_plainrest}contacts/pid?id={model.ProfileId}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        if (apiResponse == null)
                        {
                            contactModel = null;
                        }
                        contactModel = JsonConvert.DeserializeObject<ContactVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }

            model.contactVM = contactModel;
            model.Email = _userManager.GetEmailAsync(user).Result;
            return View(model);
        }

        public IActionResult Create()
        {
            ProfileCreateVM model = new ProfileCreateVM();
            model.getSex = model.getSexList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProfileCreateVM profileCreateVM)
        {
            string _restpath = GetHostUrl().Content + CN();

            ClaimsPrincipal currentUser = this.User;
            var currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;


            CreateProfile crProf = new CreateProfile()
            {
                Name = profileCreateVM.Name,
                Sex = profileCreateVM.SelectedSex,
                Surname = profileCreateVM.Surname,
                UserId = currentUserId
            };

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(crProf);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{_restpath}/", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
