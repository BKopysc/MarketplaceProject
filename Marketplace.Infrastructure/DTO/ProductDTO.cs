using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Infrastructure.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String StatusType { get; set; }
        public ICollection<OfferDTO> Offers { get; set; }
    }
}
