using Marketplace.Core.Domain;
using Marketplace.Core.Repositories;
using Marketplace.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Infrastructure.Services
{

    public class CommentService
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


    }
}
