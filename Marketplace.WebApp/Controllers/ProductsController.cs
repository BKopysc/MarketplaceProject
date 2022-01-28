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
    public class ProductsController : Controller
    {
        public IConfiguration Configuration;
        private UserManager<ApplicationUser> _userManager;

        public ProductsController(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            Configuration = configuration;
            _userManager = userManager;
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

        public async Task<IActionResult> Index()
        {
            //string _restpath = "http://localhost:5000/skijumper";

            string _restpath = GetHostUrl().Content + CN();
            List<ProductVM> productsList = new List<ProductVM>();

            int profileID = await GetProfiledAsync();

            if(profileID == -1)
            {
                return RedirectToAction("Index", "Home");
            }

            Console.WriteLine($"{_restpath}/pid?pid={profileID}");

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/pid?pid={profileID}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productsList = JsonConvert.DeserializeObject<List<ProductVM>>(apiResponse);
                }
            }
            return View(productsList);
        }

        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            ProductVM s = new ProductVM();

            int profileID = await GetProfiledAsync();

            if (profileID == -1)
            {
                return RedirectToAction("Index", "Home");
            }

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<ProductVM>(apiResponse);
                }
            }

            if (s.ProfileId == profileID)
            {
                return View(s);
            }

            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductVM s, int id) //strongly type view
        {
            string _restpath = GetHostUrl().Content + CN();

            ProductVM ofResult = new ProductVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(s);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync(); //mozna zwrocic caly obiekt ktory zostal zedytowany
                        ofResult = JsonConvert.DeserializeObject<ProductVM>(apiResponse);
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
            ProductVM of = new ProductVM();

            int profileID = await GetProfiledAsync();

            if (profileID == -1)
            {
                return RedirectToAction("Index", "Home");
            }

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    of = JsonConvert.DeserializeObject<ProductVM>(apiResponse);
                }
            }
            if (of.ProfileId == profileID)
            {
                return View(of);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductVM s, int id) 
        {
            string _restpath = GetHostUrl().Content + CN();

            ProductVM ofResult = new ProductVM();

            int profileID = await GetProfiledAsync();

            // Nalezy sprawdzic czy uzytkownik jest wlascicielem. Trzeba wykonac metode GET

            //if (ofResult.ProfileId == profileID)
            //{
            //    return View(ofResult);
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home");
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
        public async Task<IActionResult> Create(ProductVM s) //strongly type view
        {
            string _restpath = GetHostUrl().Content + CN();
            string _plainrest = GetHostUrl().Content;


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

            //ProductVM ofResult = new ProductVM();

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
                        //ofResult = JsonConvert.DeserializeObject<ProductVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
