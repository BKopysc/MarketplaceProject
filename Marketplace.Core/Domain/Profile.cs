using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Core.Domain
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Sex { get; set; } // Płeć

        //Contact, Offers, Products

        public Contact Contact { get; set; }
        
        public List<Offer> Offers { get; set; }
        public List<Product> Products { get; set; }

        public String UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
