using MovieHouse.Infrastructure.Data.Identity;
using MovieHouse.Infrastructure.Data.Models;
using MovieHouse.Infrastructure.Data.Repositories;
using System.ComponentModel.DataAnnotations;

namespace MovieHouse.Core.Models
{
    public class UserViewModel
    {
        
       
        public UserViewModel(ApplicationUser user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Password = user.PasswordHash; 
            Country = user.Country;
            City = user.City;
            Age = user.Age;
            ProfilePicture = user.ProfilePicture;
           
        }

        public UserViewModel()
        {

        }


        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string Password { get; set; }

        [Required]
        public string LastName { get; set; }
        
        public int Age { get; set; }

        public string? ProfilePicture { get; set; }

        [Required]
        public Country Country { get; set; }

        [Required]
        public City City { get; set; }

        public string Initial { get; set; }
        public IEnumerable<Country> CountryList { get; set; }




        //public ICollection<UserMovies> FavoriteMovies { get; set; }
        //public ICollection<UserMoviesReviews> MoviesReviews { get; set; }
        //public ICollection<UserMoviesRating> UserMoviesRating { get; set; }
    }
}
