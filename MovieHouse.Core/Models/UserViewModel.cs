using MovieHouse.Infrastructure.Data.Identity;
using MovieHouse.Infrastructure.Data.Models;
using MovieHouse.Infrastructure.Data.Repositories;

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


        public string Id { get; set; }
        public string FirstName { get; set; }

        public string Password { get; set; }

        public string LastName { get; set; }
        
        public int Age { get; set; }

        public string? ProfilePicture { get; set; }

        public Country Country { get; set; }


        public City City { get; set; }

        public string Initial { get; set; }

        


        //public ICollection<UserMovies> FavoriteMovies { get; set; }
        //public ICollection<UserMoviesReviews> MoviesReviews { get; set; }
        //public ICollection<UserMoviesRating> UserMoviesRating { get; set; }
    }
}
