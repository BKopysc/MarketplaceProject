using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.WebApp.Models
{
    public class OfferProductsVM
    {
        public int OfferId { get; set; }
        public String OfferName { get; set; }
        public double OfferPrice { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ProfileId { get; set; }

        public List<ProductVM> ProductList{ get; set; }

    }
}
