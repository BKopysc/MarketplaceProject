using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Infrastructure.Commands
{
    public class CreateOffer_Product
    {
        public int Id { get; set; }

        public int OfferId { get; set; }
        //public Offer Offer { get; set; }

        public int ProductId { get; set; }
        //public Product Product { get; set; }
    }
}
