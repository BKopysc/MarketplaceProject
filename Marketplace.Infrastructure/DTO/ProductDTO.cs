using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Infrastructure.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public int Name { get; set; }
        public int Description { get; set; }
        public String StatusType { get; set; }

        public ICollection<OfferDTO> Offers { get; set; }
    }
}
