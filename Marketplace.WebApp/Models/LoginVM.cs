using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.WebApp.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email jest wymagany...")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]

        public string UserName { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane...")]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
