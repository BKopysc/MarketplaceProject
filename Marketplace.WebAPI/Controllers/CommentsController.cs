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
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            IEnumerable<CommentDTO> z = await _commentService.BrowseAll();
            return Json(z);
        }

        //https://localhost:5001/comment/{id}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOffer(int id)
        {
            Console.WriteLine($"get: {id}");
            CommentDTO z = await _commentService.GetComment(id);
            return Json(z);
        }

        ////https://localhost:5001/skijumper/filter?name=alan&country=ger
        //[HttpGet("filter")]
        //public async Task<IActionResult> GetByFilter(string name, string country)
        //{
        //    Console.WriteLine($"Get Filter: name: {name}, country: {country}");
        //    IEnumerable<SkiJumperDTO> z = await _skiJumperService.BrowseWithFilter(name, country);
        //    return Json(z);
        //}

        [HttpPost]
        public async Task<IActionResult> AddOffer([FromBody] CreateComment comment)
        {
            Console.WriteLine($"Post: id - {comment.CommentId}");
            CommentDTO z = await _commentService.AddComment(comment);
            return Json(z);
        }

        [HttpPut("{id}")]
        public async Task UpdateOffer([FromBody] UpdateComment comment, int id)
        {
            Console.WriteLine($"Put: id {id}");
            await _commentService.UpdateComment(comment, id);
            //return Json(z);
        }

        [HttpDelete("{id}")]
        public async Task DeleteOffer(int id)
        {
            Console.WriteLine($"Delete: id {id}");
            await _commentService.DeleteComment(id);
            //return Json(z);
        }
    }
}
