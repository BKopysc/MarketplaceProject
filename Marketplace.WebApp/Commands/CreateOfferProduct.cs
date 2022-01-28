using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.WebApp.Commands
{
    public class CreateOfferProduct
    {
        public int Id { get; set; }
        public int OfferId { get; set; }
        public int ProductId { get; set; }

    }
}
