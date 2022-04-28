using Microsoft.AspNetCore.Mvc.Rendering;
using MovieHouse.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieHouse.Areas.Administration.Models
{
    public class AddMovieViewModel
    {
       

        [Required]
        public string Name { get; set; }

        [Required]
        public string ReleaseDate { get; set; }


        public string? CoverPhoto { get; set; }

        [Display(Name = "Country")]
        public string CountryId { get; set; }

        [Display(Name = "Directed By")]
        public string? DirectedById { get; set; }

        public IEnumerable<Country> CountryList { get; set; } = new List<Country>();

        public List<SelectListItem> Genres { get; set; }


        public List<SelectListItem> Actors { get; set; }
        public ICollection<UserMovies> FavoritedBy { get; set; }
        public ICollection<UserMoviesReviews> Reviews { get; set; }
        public ICollection<UserMoviesRating> Ratings { get; set; }

        public List<string> ActorsIds { get; set; }
        public List<string> GenresIds { get; set; }

        public AddMovieViewModel()
        {
            Genres = new List<SelectListItem>();
            Actors = new List<SelectListItem>();
            FavoritedBy = new List<UserMovies>();
            Reviews = new List<UserMoviesReviews>();
            Ratings = new List<UserMoviesRating>();
            ActorsIds = new List<string>();
            GenresIds = new List<string>();
        }
    }
}
