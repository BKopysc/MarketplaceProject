using Marketplace.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.WebApp.Controllers
{
    public class OffersController : Controller
    {
        public IConfiguration Configuration;

        public OffersController(IConfiguration configuration)
        {
            Configuration = configuration;
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

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    of = JsonConvert.DeserializeObject<OfferVM>(apiResponse);
                }
            }
            return View(of);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(OfferVM s, int id) //strongly type view
        {
            string _restpath = GetHostUrl().Content + CN();

            OfferVM ofResult = new OfferVM();

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



    }
}
