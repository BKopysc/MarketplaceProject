using Marketplace.Core.Domain;
using Marketplace.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Infrastructure.Repositories
{
    class CommentRepository : ICommentRepository
    {
        private AppDbContext _appDbContext;

        public CommentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Comment> AddSync(Comment c)
        {
            try
            {
                _appDbContext.Comment.Add(c);
                _appDbContext.SaveChanges();

                Console.WriteLine(c.CommentId);

                //Task.CompletedTask;
                return await Task.FromResult(_appDbContext.Comment.FirstOrDefault(x => x.CommentId == c.CommentId));
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task<IEnumerable<Comment>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Comment);
        }

        public async Task DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Comment.FirstOrDefault(x => x.CommentId == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Comment> GetAsync(int id)
        {
            try
            {
                return await Task.FromResult(_appDbContext.Comment.FirstOrDefault(x => x.CommentId == id));

            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task<Comment> UpdateAsync(Comment c, int id)
        {
            try
            {
                var z = _appDbContext.Comment.FirstOrDefault(x => x.CommentId == id);

                if (z == null)
                {
                    return null;
                }

                z.AuthorName = c.AuthorName;
                z.CreatedDate = c.CreatedDate;
                z.Text = c.Text;

                _appDbContext.SaveChanges();

                await Task.CompletedTask;
                return (z);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }
    }
}
