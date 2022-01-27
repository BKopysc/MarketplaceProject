using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.WebApp.Models
{
    public class OfferDetailsVM
    {
        public int OfferId { get; set; }
        public String OfferName { get; set; }
        public double OfferPrice { get; set; }
        public bool OfferActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }

        public ContactVM contactVM { get; set; }

    }
}
