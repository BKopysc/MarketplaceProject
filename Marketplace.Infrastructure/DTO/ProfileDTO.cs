using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Infrastructure.DTO
{
    public class ProfileDTO
    {
        public int ProfileId { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Sex { get; set; }

        //Contact, Offers, Products

        public ContactDTO Contact { get; set; }

        public List<OfferDTO> Offers { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
