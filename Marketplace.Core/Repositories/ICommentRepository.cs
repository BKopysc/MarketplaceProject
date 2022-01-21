using Marketplace.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Repositories
{
    public interface ICommentRepository
    {
        Task UpdateAsync(Comment c, int id);
        Task<Comment> AddSync(Comment c);
        Task DelAsync(int id);
        Task<Comment> GetAsync(int id);
        Task<IEnumerable<Comment>> BrowseAllAsync();
    }
}
