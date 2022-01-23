using Marketplace.Core.Domain;
using Marketplace.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Infrastructure.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        //public static List<Offer> _offerMock = new List<Offer>();
        //public OfferRepository()
        //{
        //    _offerMock.Add(new Offer()
        //    {
        //        OfferId = 1,
        //        AuthorName = "Adam",
        //        Active = true,
        //        Comments = null,
        //        CreatedDate = new DateTime(),
        //        Name = "Sofa",
        //        Price = 100,
        //        Products = null
        //    }) ;
        //}

        private AppDbContext _appDbContext;

        public OfferRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Offer> AddSync(Offer o)
        {
            try
            {
                _appDbContext.Offer.Add(o);
                _appDbContext.SaveChanges();

                Console.WriteLine(o.OfferId);

                //Task.CompletedTask;
                return await Task.FromResult(_appDbContext.Offer.FirstOrDefault(x => x.OfferId == o.OfferId));
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task<IEnumerable<Offer>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Offer);
        }

        public async Task<IEnumerable<Offer>> BrowseWithFilterAsync(string name, bool active)
        {
            var o = _appDbContext.Offer.Where(x => x.Name.Contains(name) && x.Active == active).AsEnumerable();
            return await Task.FromResult(o);
        }

        public async Task DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Offer.FirstOrDefault(x => x.OfferId == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Offer> GetAsync(int id)
        {
            try
            {
                return await Task.FromResult(_appDbContext.Offer.FirstOrDefault(x => x.OfferId == id));

            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task<Offer> UpdateAsync(Offer o, int id)
        {
            try
            {
                var z = _appDbContext.Offer.FirstOrDefault(x => x.OfferId == id);

                if (z == null)
                {
                    return null;
                }


                z.Name = o.Name;
                //z.OfferId = o.OfferId;
                z.Active = o.Active;
                z.Comments = o.Comments;
                z.Price = o.Price;

                z.CreatedDate = o.CreatedDate;
                z.Products = o.Products;

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
