using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.WebApp.Models
{
    public class OfferVM
    {
        public int OfferId { get; set; }
        public String Name { get; set; }
        public String AuthorName { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }

        //public ICollection<Product> Products { get; set; }
        //public List<Comment> Comments { get; set; }
    }
}
