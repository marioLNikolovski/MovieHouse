using Microsoft.AspNetCore.Mvc.Rendering;
using MovieHouse.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Globalization;


namespace MovieHouse.Core.Models
{
    public class EditActorViewModel
    {
        public EditActorViewModel(Actor actor)
        {
            actor.Id = Id;
            actor.FirstName = FirstName;
            actor.LastName = LastName;
            actor.BirthCityId = BirthCityId;
            actor.BirthCountryId = BirthCountryId;
            actor.Photo = Photo;
            actor.BirthDate = DateTime.ParseExact(BirthDate, "dd.mm.yyyy", CultureInfo.InvariantCulture);
            ActedInIds = new List<string>();
            ActedIn = new List<SelectListItem>();
        }
        public EditActorViewModel()
        {
             ActedIn = new List<SelectListItem> { };
            ActorList = new List<SelectListItem>();
        }
        public string Id { get; set; }

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

        [Display(Name = "Photo Url")]
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
        public List<SelectListItem> ActorList { get; set; }

    }
}
