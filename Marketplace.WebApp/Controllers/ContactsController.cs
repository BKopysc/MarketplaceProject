using Marketplace.Core.Domain;
using Marketplace.WebApp.Models;
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
    public class ContactsController : Controller
    {
        public IConfiguration Configuration;
        private UserManager<ApplicationUser> _userManager;

        public ContactsController(IConfiguration configuration, UserManager<ApplicationUser> userManager)
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
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactVM s) //strongly type view
        {
            string _restpath = GetHostUrl().Content + CN();
            string _plainrest = GetHostUrl().Content;

            //ContactVM ofResult = new ContactVM();
            ClaimsPrincipal currentUser = this.User;
            var user = _userManager.GetUserAsync(currentUser).Result;
            var currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
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
                return View(ex);
            }

            s.ProfileId = profileModel.ProfileId;

            //post kontaktu

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
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction("Index", "Profiles");
        }

        //public async Task<IActionResult> Edit(int id)
        //{
        //    string _restpath = GetHostUrl().Content + CN();
        //    ContactVM s = new ContactVM();

        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            s = JsonConvert.DeserializeObject<ContactVM>(apiResponse);
        //        }
        //    }
        //    return View(s);

        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(ContactVM s, int id) //strongly type view
        //{
        //    string _restpath = GetHostUrl().Content + CN();

        //    ContactVM ofResult = new ContactVM();

        //    try
        //    {
        //        using (var httpClient = new HttpClient())
        //        {
        //            string jsonString = System.Text.Json.JsonSerializer.Serialize(s);
        //            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

        //            using (var response = await httpClient.PutAsync($"{_restpath}/{id}", content))
        //            {
        //                string apiResponse = await response.Content.ReadAsStringAsync(); //mozna zwrocic caly obiekt ktory zostal zedytowany
        //                ofResult = JsonConvert.DeserializeObject<ContactVM>(apiResponse);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return View(ex);
        //    }
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
