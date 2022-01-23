using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Core.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String StatusType { get; set; }

        public ICollection<Offer> Offers { get; set; }
        public int? ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
