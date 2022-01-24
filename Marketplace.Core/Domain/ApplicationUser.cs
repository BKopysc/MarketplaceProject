using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Core.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public Profile Profile { get; set; }
    }
}
