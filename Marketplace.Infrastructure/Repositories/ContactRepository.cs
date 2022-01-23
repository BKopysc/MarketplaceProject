using Marketplace.Core.Domain;
using Marketplace.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private AppDbContext _appDbContext;

        public ContactRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Contact> AddSync(Contact c)
        {
            try
            {
                _appDbContext.Contact.Add(c);
                _appDbContext.SaveChanges();

                Console.WriteLine(c.ContactId);

                //Task.CompletedTask;
                return await Task.FromResult(_appDbContext.Contact.FirstOrDefault(x => x.ContactId == c.ContactId));
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task<IEnumerable<Contact>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Contact);
        }

        public async Task DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Contact.FirstOrDefault(x => x.ContactId == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Contact> GetAsync(int id)
        {
            try
            {
                return await Task.FromResult(_appDbContext.Contact.FirstOrDefault(x => x.ContactId == id));

            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task<Contact> UpdateAsync(Contact c, int id)
        {
            try
            {
                var z = _appDbContext.Contact.FirstOrDefault(x => x.ContactId == id);

                if (z == null)
                {
                    return null;
                }

                z.City = z.City;
                z.Country = z.Country;
                z.County = z.County;
                z.Phone = z.Phone;

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
