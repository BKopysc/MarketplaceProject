using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.WebApp.Models
{
    public class ProfileCreateVM
    {

        [Required(ErrorMessage = "Imie jest wymagane")]
        [Display(Name = "Imie")]
        [DataType(DataType.Text)]

        public string Name { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane...")]
        [Display(Name = "Nazwisko")]
        [DataType(DataType.Text)]

        public string Surname { get; set; }

        [Required(ErrorMessage = "Plec jest wymagana...")]
        [Display(Name = "Plec")]
        public string SelectedSex { get; set; }
        public List<SelectListItem> getSex { get; set; }
        public List<SelectListItem> getSexList()
        {
            List<SelectListItem> sexList = new List<SelectListItem>();
            var data = new[]
            {
                new SelectListItem() { Text = "Mężczyzna", Value = "Mężczyzna" },
            new SelectListItem() { Text = "Kobieta", Value = "Kobieta" },
            new SelectListItem() { Text = "Wolę nie podawać", Value = "Brak danych" },
            };
            sexList = data.ToList();
            return sexList;
        }
        //[DataType(DataType.Text)]

    }
}
