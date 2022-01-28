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
    public class OffersProductsController : Controller
    {
        public IConfiguration Configuration;
        private UserManager<ApplicationUser> _userManager;
        public OffersProductsController(IConfiguration configuration, UserManager<ApplicationUser> userManager)
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

        public async Task<IActionResult> AddProduct(int id)
        {
            int profileID = await GetProfiledAsync();

            if (profileID == -1)
            {
                return RedirectToAction("Index", "Home");
            }

            string _restpath = GetHostUrl().Content + CN();
            string _plainrest = GetHostUrl().Content;

            OfferVM off = new OfferVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_plainrest}Offers/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    off = JsonConvert.DeserializeObject<OfferVM>(apiResponse);
                }
            }

            // Pobranie listy produktów użytkownika

            List<ProductVM> productsList = new List<ProductVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_plainrest}products/pid?pid={profileID}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productsList = JsonConvert.DeserializeObject<List<ProductVM>>(apiResponse);
                }
            }

            List<SelectListItem> productItemList = new List<SelectListItem>();
            
            foreach (ProductVM pr in productsList)
            {
                SelectListItem n = new SelectListItem()
                {
                    Text = pr.Name,
                    Value = (pr.ProductId).ToString()
                };
                productItemList.Add(n);
            }

            OfferProductsVM OP = new OfferProductsVM()
            {
                OfferName = off.Name,
                getProduct = productItemList
            };

            return View(OP);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(OfferProductsVM off)
        {
            //string _restpath = GetHostUrl().Content + CN();
            string _plainrest = GetHostUrl().Content;

            CreateOfferProduct cop = new CreateOfferProduct()
            {
                OfferId = off.OfferId,
                ProductId = Int32.Parse(off.SelectedProduct)
            };

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(cop);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync($"{_plainrest}Offers_Products", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync(); 
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }

            return RedirectToAction("Yours", "Offers");
        }
        

        
    }
}
