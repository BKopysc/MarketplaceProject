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

    public class CommentService: ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        private CommentDTO MakeDTO(Comment c)
        {
            CommentDTO comDTO = new CommentDTO()
            {
                AuthorName = c.AuthorName,
                CommentId = c.CommentId,
                CreatedDate = c.CreatedDate,
                Text = c.Text
            };
            return comDTO;
        }

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<CommentDTO>> BrowseAll()
        {
            var z = await _commentRepository.BrowseAllAsync();
            return z.Select(x => MakeDTO(x));
        }

        public async Task<CommentDTO> GetComment(int id)
        {
            var z = await _commentRepository.GetAsync(id);

            if (z == null)
            {
                return null;
            }
            return MakeDTO(z);
        }

        public async Task<CommentDTO> AddComment(CreateComment comment)
        {
            Comment of = new Comment()
            {
                CommentId = comment.CommentId,
                AuthorName = comment.AuthorName,
                CreatedDate = comment.CreatedDate,
                Text = comment.Text,
            };

            var z = await _commentRepository.AddSync(of);

            if (z == null)
            {
                return null;
            }

            Console.WriteLine(z.CommentId);
            return MakeDTO(z);
        }

        public async Task<CommentDTO> UpdateComment(UpdateComment comment, int id)
        {
            Comment of = new Comment()
            {
                AuthorName = comment.AuthorName,
                CreatedDate = comment.CreatedDate,
                Text = comment.Text,
            };

            var z = await _commentRepository.UpdateAsync(of, id);

            if (z == null)
            {
                return null;
            }
            return MakeDTO(z);
        }

        public async Task DeleteComment(int id)
        {
            await _commentRepository.DelAsync(id);
        }






    }
}
