using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Core.Domain
{
    public class Offer_Product
    {
        public int Id { get; set; }

        public int OfferId { get; set; }
        public Offer Offer { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
