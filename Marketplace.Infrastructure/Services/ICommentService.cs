using Marketplace.Infrastructure.Commands;
using Marketplace.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Infrastructure.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDTO>> BrowseAll();

        Task<CommentDTO> GetComment(int id);

        Task<CommentDTO> AddComment(CreateComment comment);

        Task<CommentDTO> UpdateComment(UpdateComment comment, int id);

        Task DeleteComment(int id);
    }
}
