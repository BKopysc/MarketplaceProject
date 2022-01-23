using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Infrastructure.Commands
{
    public class UpdateContact
    {
        //public int ContactId { get; set; }
        public String Country { get; set; }
        public String County { get; set; }
        public String City { get; set; }
        public String Phone { get; set; }

        public int ProfileId { get; set; }
        //public Profile Profile { get; set; }
    }
}
