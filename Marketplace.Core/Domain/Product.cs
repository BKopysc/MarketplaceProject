using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Core.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public int Name { get; set; }
        public int Description { get; set; }
        public String StatusType { get; set; }

        public ICollection<Offer> Offers { get; set; }

    }
}
