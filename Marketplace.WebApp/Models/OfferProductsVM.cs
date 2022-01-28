using Microsoft.AspNetCore.Mvc.Rendering;
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
        public int ProfileId { get; set; }

        public string SelectedProduct { get; set; }
        public List<SelectListItem> getProduct { get; set; }

        //public List<ProductVM> ProductList{ get; set; }

    }
}
