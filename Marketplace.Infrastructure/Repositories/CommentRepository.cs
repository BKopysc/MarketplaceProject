﻿using Marketplace.Core.Domain;
using Marketplace.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Infrastructure.Repositories
{
    class CommentRepository : ICommentRepository
    {
        public Task<Comment> AddSync(Comment c)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comment>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Comment c, int id)
        {
            throw new NotImplementedException();
        }
    }
}
