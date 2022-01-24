using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.WebApp.Models
{

    public class ProfileVM
    {
        public int ProfileId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Sex { get; set; }

        public ContactVM contactVM { get; set; }

    }
}
