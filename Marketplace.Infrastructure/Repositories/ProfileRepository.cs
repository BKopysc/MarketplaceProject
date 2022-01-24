using Marketplace.Core.Domain;
using Marketplace.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Infrastructure.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private AppDbContext _appDbContext;

        public ProfileRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Profile> AddSync(Profile p)
        {
            try
            {
                _appDbContext.Profile.Add(p);
                _appDbContext.SaveChanges();

                Console.WriteLine(p.ProfileId);

                //Task.CompletedTask;
                return await Task.FromResult(_appDbContext.Profile.FirstOrDefault(x => x.ProfileId == p.ProfileId));
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task<IEnumerable<Profile>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Profile);
        }

        public async Task DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Profile.FirstOrDefault(x => x.ProfileId == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Profile> GetAsync(int id)
        {
            try
            {
                return await Task.FromResult(_appDbContext.Profile.FirstOrDefault(x => x.ProfileId == id));

            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task<Profile> GetByUIDAsync(string id)
        {
            try
            {
                return await Task.FromResult(_appDbContext.Profile.FirstOrDefault(x => x.UserId == id));

            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task<Profile> UpdateAsync(Profile p, int id)
        {
            try
            {
                var z = _appDbContext.Profile.FirstOrDefault(x => x.ProfileId == id);

                if (z == null)
                {
                    return null;
                }

                z.Name = z.Name;
                //z.Products = z.Products;
                z.Sex = z.Sex;
                z.Surname = z.Surname;

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
