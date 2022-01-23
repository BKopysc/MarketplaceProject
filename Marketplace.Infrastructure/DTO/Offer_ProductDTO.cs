using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Infrastructure.DTO
{
    public class Offer_ProductDTO
    {
        public int Id { get; set; }

        public int OfferId { get; set; }
        public OfferDTO Offer { get; set; }

        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }
    }
}
