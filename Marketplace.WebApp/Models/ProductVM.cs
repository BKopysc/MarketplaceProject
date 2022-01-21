using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.WebApp.Models
{
    public class ProductVM
    {
        public int ProductId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String StatusType { get; set; }
    }
}
