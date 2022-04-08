using Microsoft.AspNetCore.Identity;
using MovieHouse.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieHouse.Infrastructure.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [RegularExpression(@"([A-Z][a-z]{1,36})([\\s\\\'-][A-Z][a-z]{1,36})*")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"([A-Z][a-z]{1,60})")]
        public string LastName { get; set; }
        [Required]
        [Range(18, 99)]
        public int Age { get; set; }

        public string ProfilePicture { get; set; }

        public string CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }


        public string CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public City City { get; set; }

        public ICollection<UserMovies> FavoriteMovies { get; set; }
        public ICollection<UserMoviesReviews> MoviesReviews { get; set; }
        public ICollection<UserMoviesRating> UserMoviesRating { get; set; }

        public ApplicationUser()
        {
            FavoriteMovies = new List<UserMovies>();
            MoviesReviews = new List<UserMoviesReviews>();
            UserMoviesRating = new List<UserMoviesRating>();
        }
    }
}
