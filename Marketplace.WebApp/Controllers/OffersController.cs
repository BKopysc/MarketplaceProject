using Marketplace.Core.Domain;
using Marketplace.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    [Authorize]
    public class OffersController : Controller
    {
        public IConfiguration Configuration;
        private UserManager<ApplicationUser> _userManager;
        public OffersController(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            Configuration = configuration;
            _userManager = userManager;
        }

        private async Task<string> GetEmailAsync()
        {
            string _plainrest = GetHostUrl().Content;

            ClaimsPrincipal currentUser = this.User;
            var user = _userManager.GetUserAsync(currentUser).Result;
            var currentUserId = "";

            if (currentUser.Identity.IsAuthenticated)
            {
                return user.Email;
            }
            else
            {
                return "";
            }


        }

        private async Task<int> GetProfiledAsync()
        {
            string _plainrest = GetHostUrl().Content;

            ClaimsPrincipal currentUser = this.User;
            var user = _userManager.GetUserAsync(currentUser).Result;
            var currentUserId = "";

            if (currentUser.Identity.IsAuthenticated)
            {
                currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
            else
            {
                return -1;
            }

            ProfileVM profileModel = new ProfileVM();

            //Pobranie Usera
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync($"{_plainrest}Profiles/uid?id={currentUserId}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        profileModel = JsonConvert.DeserializeObject<ProfileVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return (-1);
            }

            return (profileModel.ProfileId);

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

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {

            string _restpath = GetHostUrl().Content + CN();
            List<OfferVM> offersList = new List<OfferVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    offersList = JsonConvert.DeserializeObject<List<OfferVM>>(apiResponse);
                }
            }
            return View(offersList);
        }

        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            OfferVM s = new OfferVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<OfferVM>(apiResponse);
                }
            }
            return View(s);

        }

        public async Task<IActionResult> Yours()
        {
            string _restpath = GetHostUrl().Content + CN();
            List<OfferVM> offersList = new List<OfferVM>();

            int profileID = await GetProfiledAsync();


            if (profileID == -1)
            {
                return RedirectToAction("Index", "Home");
            }

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/pid?pid={profileID}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    offersList = JsonConvert.DeserializeObject<List<OfferVM>>(apiResponse);
                }
            }
            return View(offersList);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OfferVM s, int id) //strongly type view
        {
            string _restpath = GetHostUrl().Content + CN();

            OfferVM ofResult = new OfferVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(s);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync(); //mozna zwrocic caly obiekt ktory zostal zedytowany
                        ofResult = JsonConvert.DeserializeObject<OfferVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            OfferVM of = new OfferVM();

            ClaimsPrincipal currentUser = this.User;
            var user = _userManager.GetUserAsync(currentUser).Result;
            var currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            int profileid = await GetProfiledAsync();

 

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    of = JsonConvert.DeserializeObject<OfferVM>(apiResponse);
                }
            }

            if (of.ProfileId != profileid)
            {

                var isAdmin = _userManager.IsInRoleAsync(user, "admin").Result;
                if (isAdmin == false)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(of);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(OfferVM s, int id)
        {
            string _restpath = GetHostUrl().Content + CN();

            ClaimsPrincipal currentUser = this.User;
            var user = _userManager.GetUserAsync(currentUser).Result;
            var currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            OfferVM ofResult = new OfferVM();

            int profileid = await GetProfiledAsync();
            

            //if(s.ProfileId != profileid)
            //{
               
            //    var isAdmin = _userManager.IsInRoleAsync(user, "admin").Result;
            //    if (isAdmin == false)
            //    {
            //        return RedirectToAction(nameof(Index));
            //    }
            //}

            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync($"{_restpath}/{id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OfferVM s) //strongly type view
        {
            string _restpath = GetHostUrl().Content + CN();

            OfferVM ofResult = new OfferVM();

            int ProfileID = await GetProfiledAsync();

            s.ProfileId = ProfileID;
            s.CreatedDate = DateTime.Now;

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(s);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    Console.WriteLine(content);
                    using (var response = await httpClient.PostAsync($"{_restpath}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync(); //mozna zwrocic caly obiekt ktory zostal zedytowany
                        ofResult = JsonConvert.DeserializeObject<OfferVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Details(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            string _plainrest = GetHostUrl().Content;

            OfferVM s = new OfferVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<OfferVM>(apiResponse);
                }
            }

            var offerUserId = s.ProfileId;

            ProfileVM profileModel= new ProfileVM();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync($"{_plainrest}Profiles/{offerUserId}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        profileModel = JsonConvert.DeserializeObject<ProfileVM>(apiResponse);
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
                    using (var response = await httpClient.GetAsync($"{_plainrest}contacts/pid?id={offerUserId}"))
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


            OfferDetailsVM ODv = new OfferDetailsVM()
            {
                OfferId = s.OfferId,
                OfferName = s.Name,
                OfferPrice = s.Price,
                OfferActive = s.Active,
                CreatedDate = s.CreatedDate,
                Name = profileModel.Name,
                Surname = profileModel.Surname,
                contactVM = contactModel
            };

            return View(ODv);
        }



    }
}
