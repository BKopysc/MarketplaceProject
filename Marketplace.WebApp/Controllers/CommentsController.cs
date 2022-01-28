using Marketplace.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class CommentsController : Controller
    {
        public IConfiguration Configuration;

        public CommentsController(IConfiguration configuration)
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

            string _restpath = GetHostUrl().Content + CN();
            List<CommentVM> commentsList = new List<CommentVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    commentsList = JsonConvert.DeserializeObject<List<CommentVM>>(apiResponse);
                }
            }
            return View(commentsList);
        }
        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            CommentVM s = new CommentVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<CommentVM>(apiResponse);
                }
            }
            return View(s);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(CommentVM s, int id) //strongly type view
        {
            string _restpath = GetHostUrl().Content + CN();

            CommentVM ofResult = new CommentVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(s);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync(); //mozna zwrocic caly obiekt ktory zostal zedytowany
                        ofResult = JsonConvert.DeserializeObject<CommentVM>(apiResponse);
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
            CommentVM of = new CommentVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    of = JsonConvert.DeserializeObject<CommentVM>(apiResponse);
                }
            }
            return View(of);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CommentVM s, int id) //strongly type view
        {
            string _restpath = GetHostUrl().Content + CN();

            CommentVM ofResult = new CommentVM();

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
        public async Task<IActionResult> Create(CommentVM s) //strongly type view
        {
            string _restpath = GetHostUrl().Content + CN();

            CommentVM ofResult = new CommentVM();

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
                        ofResult = JsonConvert.DeserializeObject<CommentVM>(apiResponse);
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
