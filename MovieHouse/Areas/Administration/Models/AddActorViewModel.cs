﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieHouse.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieHouse.Areas.Administration.Models
{
    public class AddActorViewModel 
    {

        public AddActorViewModel()
        {

            ActedInIds = new List<string>();
            ActedIn = new List<SelectListItem>();
        }
       

        
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Birthdate")]
        public string BirthDate { get; set; }

        [Required]
        public int Age { get; set; }

        public string? Photo { get; set; }

        [Required]
        [Display(Name = "City")]
        public string BirthCityId { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string BirthCountryId { get; set; }


        [Display(Name = "Acted in Movies")]
        public List<SelectListItem> ActedIn { get; set; }

        public List<string> ActedInIds { get; set; }

        public IEnumerable<Country> CountryList { get; set; } = new List<Country>();


    }
}
