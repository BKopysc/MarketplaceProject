using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.WebApp.Models
{
    public class ContactVM
    {
        public int ContactID { get; set; }
        public int ProfileId { get; set; }
        public String Country { get; set; }
        public String County { get; set; }
        public String City { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Niepoprawny numer telefonu")]
        public String Phone { get; set; }
    }
}
