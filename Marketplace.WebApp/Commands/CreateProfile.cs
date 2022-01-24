using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.WebApp.Commands
{
    public class CreateProfile
    {
        public int ProfileId { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Sex { get; set; }
        public String UserId { get; set; }

        //Contact, Offers, Products

        //public Contact Contact { get; set; }

        //public List<Offer> Offers { get; set; }
        //public List<Product> Products { get; set; }
    }
}
