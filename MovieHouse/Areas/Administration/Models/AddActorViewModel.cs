using Microsoft.AspNetCore.Mvc;
using MovieHouse.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieHouse.Areas.Administration.Models
{
    public class AddActorViewModel 
    {

        public AddActorViewModel()
        {
            ActedIn = new List<ActorMovies>();
            DirectedMovies = new List<Movie>();
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


        [Display(Name = "Acted Movies")]
        public ICollection<ActorMovies> ActedIn { get; set; }

        [Display(Name = "Directed Movies")]
        public ICollection<Movie> DirectedMovies { get; set; }


    }
}
